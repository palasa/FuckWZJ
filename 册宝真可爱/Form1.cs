using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using 册宝真可爱.Entitys;
using 册宝真可爱.Enums;
using 册宝真可爱.Exceptions;
using 册宝真可爱.Utils;

namespace 册宝真可爱
{
    public partial class Form1 : Form
    {
        private ConnectionUtil util = new ConnectionUtil();

        private CookieContainer cc = new CookieContainer();

        private List<Live> allLives = new List<Live>();

        private bool login = false;

        private bool buyOK = false;

        private static Random r = new Random();

        private static DateTime serverDateTime;
        private static TimeSpan timeSpan;

        public Form1()
        {
            
            InitializeComponent();

            Form1.CheckForIllegalCrossThreadCalls = false;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = this.txtUsername.Text;
            string password = this.txtPassword.Text;
            string postData = string.Format("username={0}&password={1}&code=&return_url=https%3A%2F%2Fshop.48.cn%2Fhome%2Findex" , username , password );

            string loginResult = util.POST("http://user.snh48.com/Login/dologin.html", cc ,  postData);

            if (loginResult.Contains("{\"status\":\"1001\""))
            {
                ShowError("用户名或密码错误");
            }
            else
            {
                // 登录成功 ，解析返回的 url                 
                loginResult = loginResult.Replace("\\" , "");
                this.Text = username;

                /*
                 * <script type="text/javascript" src="http://user.snh48.com/api/uc.php?time=1541052675&code=a498X77nX" reload="1"><\/script>
                 */
                Regex regex = new Regex(" src=\".{10,700} reload");
                MatchCollection matchCollection = regex.Matches(loginResult);

                // 分别向每个独立的url地址发请求
                Task.Factory.StartNew(() =>
                {
                    foreach (var item in matchCollection)
                    {
                        string text2 = item.ToString();
                        int num = text2.IndexOf("?");
                        string url = text2.Substring(6, text2.Length - 14);
                        util.GET(url, this.cc);
                    }
                }).ContinueWith(t => {
                    login = true;
                    this.btnBuyOne.Enabled = true;
                    this.btnBuyGoods.Enabled = true;
                    this.gbLogin.Enabled = false;
                });
                

                
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            timerSyncDateTime_Tick(null, null);

            this.gbBuyTicket.Enabled = false;
            this.btnBuyOne.Enabled = false;
            
            GetGroups();

            Task.Factory.StartNew(GetLoginPage);
            
            Task.Factory.StartNew(GetTickets).ContinueWith(task => GetTicketsDetail());


            this.timerSyncDateTime.Start();
            // 计时器部分：
            this.timerAutoBuyAtEight.Start();

        }

        /// <summary>
        /// 获取每张票务的详情
        /// </summary>
        private void GetTicketsDetail()
        {
            foreach (var live in allLives)
            {
                Task.Factory.StartNew ( ()=> 
                    live.LiveDetail = LiveUtil.GetLiveDetailByLiveId(live.TicketNumber)
                );
            }
        }

        /// <summary>
        /// // 获取可购票务列表 , 包括票务基本信息
        /// </summary>
        private void GetTickets()
        {
            // 打开票务页面
            // https://shop.48.cn/tickets

            // 查找每一个 <li class="gs_2t"><a title="星梦剧院11月11日NIII队剧场公演" href="/tickets/item/2607">广州星梦剧院11月11日NIII队剧场公演</a></li>
            var allTicketPageString = util.GET("https://shop.48.cn/tickets", cc);
            allTicketPageString = allTicketPageString.Replace("\\", "");
            Regex regexp = new Regex("<li class=\"gs_2t\">.{20,100}</a></li>");
            MatchCollection matchCollection1 = regexp.Matches(allTicketPageString);

            // 获取票务基本信息
            foreach (var item in matchCollection1)
            {
                // item : <li class="gs_2t"><a title="星梦剧院11月11日NIII队剧场公演" href="/tickets/item/2607" title="....">广州星梦剧院11月11日NIII队剧场公演</a></li>
                string liString = item.ToString();
                int num1 = liString.IndexOf("剧院");
                int num2 = liString.IndexOf("月");
                int num3 = liString.IndexOf("日");
                int num4 = liString.IndexOf("公演");

                int num5 = liString.LastIndexOf("\">");
                int num6 = liString.LastIndexOf("星梦剧院");

                int num7 = liString.LastIndexOf("item/");
                int num8 = liString.LastIndexOf("title=");

                string city = liString.Substring(num5 + 2, num6 - num5 - 2);   // 沈阳
                string month = liString.Substring(num1 + 2, num2 - num1 - 2);         // 11
                string day = liString.Substring(num2 + 1, num3 - num2 - 1);        // 10                    
                string team = liString.Substring(num3 + 1, num4 - num3 - 1); ;  // SIII队 / 预备生 
                team = team.Replace("剧场", "");
                string ticketNumber = liString.Substring(num7 + 5, num8 - num7 - 7);    // 2607

                Live live = LiveUtil.GetLive(city, month, day, team, ticketNumber);
                
                allLives.Add(live);

            }
            
            LiveUtil.allLives = allLives;

            this.ddlTicket.DisplayMember = "Name";
            this.ddlTicket.ValueMember = "Id";

            Task task = Task.Factory.StartNew(
                () => {
                    SetDdlTicket(allLives.OrderBy(live => live.Group.GroupId).ThenBy(live => live.StartTime));
                }
            ).ContinueWith( t => {
                this.ddlTicket.SelectedIndex = 0;
                this.ddlGroup.SelectedIndex = 0;
            });
            
            this.gbBuyTicket.Enabled = true;
        }

        private void SetDdlTicket( IEnumerable<Live> lives )
        {
            this.ddlTicket.Items.Clear();

            //this.ddlTicket.Items.Add(new ComboBoxListItem(-1 , "请选择票务"));

            foreach (Live live in lives)
            {
                ComboBoxListItem item = new ComboBoxListItem(
                    live.TicketNumber,
                    string.Format("{0}月{1}日 {2} Team {3} 公演", 
                    live.StartTime.Month.ToString().Length == 1 ? "0"+ live.StartTime.Month.ToString() :
                    live.StartTime.Month.ToString(), 
                    live.StartTime.Day.ToString().Length==1? "0" + live.StartTime.Day.ToString() : live.StartTime.Day.ToString() ,
                    live.Group.GroupName, live.Team.TeamName )
                );

                item.Color = live.Team.TeamColor == null ? TeamColor.Unknown : live.Team.TeamColor;

                // MessageBox.Show( live.Team.TeamColor.ToString() );
                this.ddlTicket.Items.Add(item);
            }
            
        }

        /// <summary>
        ///  读取 GroupList ， 生成 “组合” 下拉菜单的选项
        /// </summary>
        private void GetGroups()
        {
            
            Dictionary<int, string> dictGroups = EnumHepler.EnumToDictionary<GroupType>();
            this.ddlGroup.DisplayMember = "Name";
            this.ddlGroup.ValueMember = "Id";

            foreach (var item in dictGroups)
            {
                ComboBoxListItem listItem = new ComboBoxListItem(
                    item.Key, item.Value, GroupUtil.GetGroupColorByGroupId(item.Key) 
                );
                this.ddlGroup.Items.Add(listItem );               
            }

            this.ddlGroup.SelectedIndex = 0;
        }

        /// <summary>
        /// // 打开登录页面，获取cookie , 存入CookieContainer
        /// </summary>
        private void GetLoginPage()
        {
            
            string loginPage = util.GET("http://user.snh48.com/Login/index.html?return_url=https://shop.48.cn/home/index", cc);
            if (loginPage == string.Empty)
            {
                ShowError("无法打开登录页面");
            }
        }

        private void ShowError( string errorMessage)
        {
            MessageBox.Show("错误！"+errorMessage);
        }


        /// <summary>
        /// 换组合的时候，重新获取该组合的门票
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ddlGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedItem = this.ddlGroup.SelectedItem as ComboBoxListItem;
            
            Task task = Task.Factory.StartNew( ()=>
                {
                    if (selectedItem.Name != "全部")
                    {   // 获取该分团的所有门票
                        SetDdlTicket(allLives.Where(live => live.Group.GroupName == selectedItem.Name).OrderBy(live => live.StartTime).ThenBy(live => live.LiveDetail.StartTime ));
                    }
                    else
                    {
                        SetDdlTicket(allLives.OrderBy(live => live.Group.GroupId).ThenBy(live => live.StartTime).ThenBy(live => live.LiveDetail.StartTime));
                    }
                }
            );

            task.ContinueWith( t => this.ddlTicket.SelectedIndex = 0);          
            
        }


        private void buy()
        {
            EventUtil.ClearAllEvents(this.timerSubRequest, "Tick");

            try
            {
                ComboBoxListItem item = this.ddlTicket.SelectedItem as ComboBoxListItem;

                Live l = allLives.Find(live => live.TicketNumber == item.Id);

                // 普通OK
                // {"HasError":false,"ErrorCode":"","Message":"success","ReturnObject":"/TOrder/Item/181031-2-101267"}

                // {"HasError":true,"ErrorCode":"144007","Message":"此门票为限购商品，注册会员用户请于开票24小时以后尝试购买。详询客服。","ReturnObject":null}

                // {"HasError":true,"ErrorCode":"161001","Message":"请不要反复点击“立即购买”按钮，请稍等下再尝试咯，谢谢您的支持和理解~","ReturnObject":null}

                // {"HasError":true,"ErrorCode":"168802","Message":"19：00-20：00为星沃卡用户优先购买特权,请20：00参与公开销售。","ReturnObject":null}

                //  星沃卡OK
                // {"HasError":false,"ErrorCode":"","Message":"下单申请成功","ReturnObject":null}

                // 星沃卡ERROR
                // {"HasError":true,"ErrorCode":"168801","Message":"星沃卡用户购买票务享受优先购买权，每个手机号码，每周仅可优先购买一场公演，取消订单无法重复使用特权。","ReturnObject":null}


                // 转圈中
                // id=2631&num=1&seattype=4&brand_id=1&r=0.6115051392512127&choose_times_end=-1
                // {"HasError":false,"ErrorCode":"","Message":"下单申请成功","ReturnObject":null}

                // 转圈 OK
                // GET /TOrder/tickCheck?id=2631&r=0.9927577215731782
                // {"HasError":false,"ErrorCode":"success","Message":"ok","ReturnObject":"/TOrder/Item/181106-2-103055"}


                SeatType seat;
                if (radVip.Checked)
                {
                    seat = SeatType.VIP;
                }
                else if (radStand.Checked)
                {
                    seat = SeatType.站;
                }
                else
                {
                    seat = SeatType.普;
                }

                string postUrl = "https://shop.48.cn/TOrder/add";
                string postData = string.Format("id={0}&num={1}&seattype={2}&brand_id={3}&r={4}&choose_times_end=-1",
                    l.TicketNumber, this.txtNumber.Value, Convert.ToInt32(seat),
                    l.Group.GroupId, r.NextDouble()
                );


                // 购票请求
                Task.Factory.StartNew(() =>
                {
                    this.btnBuyOne.Enabled = false;
                    return util.POST(postUrl, cc, postData);
                }).ContinueWith(t =>
                {
                    //      8点普通用户切票成功
                    if ( t.Result.IndexOf("success") > -1 ||
                        // 7 点星沃卡切票成功
                       ( t.Result.IndexOf("下单申请成功") > -1 && DateTime.Now.Hour==7 )
                    )
                    {
                        this.buyOK = true;
                        MessageBox.Show("购买成功！");
                    }
                    else if (t.Result.IndexOf("161001") > -1)
                    {
                        // 10秒内再次请求
                        ShowError("点击购买按钮过于频繁！");
                    }
                    else if (t.Result.IndexOf("161005") > -1)
                    {
                        // 8点没到
                        ShowError("尚未开始购买，请稍后再试！");
                    }
                    else if (t.Result.IndexOf("168801") > -1)
                    {
                        // 星沃卡已使用
                        ShowError("星沃卡只能使用一次！");
                    }
                    else if (t.Result.IndexOf("168802") > -1)
                    {
                        // 8点没到
                        ShowError("您不是星沃卡用户，请8点再来买！");
                    }

                    else if (t.Result.IndexOf("144007") > -1)
                    {
                        // vip24小时内限购
                        ShowError("已售罄或者您不是VIP用户需要开票24小时后购买！");
                    }
                    else if (t.Result.IndexOf("144008") > -1)
                    {
                        // 取消超过一次，24小时内无法购买
                        ShowError("您已取消订单，24小时内无法重新购买");
                    }
                    else if (t.Result.IndexOf("144009") > -1)
                    {
                        // 已有同类商品
                        ShowError("您已购买此门票，请打开网页付款");
                    }
                    else if (t.Result.IndexOf("下单申请成功") > -1 && DateTime.Now.Hour >= 8)
                    {
                        // 转圈中， 发送子请求
                        timerSubRequest.Tick += (s, e) => {
                            string childRequestUrl = string.Format("https://shop.48.cn/TOrder/tickCheck?id={0}&r={1}", l.TicketNumber, r.NextDouble());
                            util.GET(childRequestUrl, cc);
                        };
                        timerSubRequest.Start();
                    }
                    // MessageBox.Show( t.Result );

                    this.btnBuyOne.Enabled = true;
                });


            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show("请先选择需要购买的门票！！");
            }
        }

        private void buyNoAlert()
        {
            EventUtil.ClearAllEvents(this.timerSubRequest, "Tick");

            try
            {
                ComboBoxListItem item = this.ddlTicket.SelectedItem as ComboBoxListItem;

                Live l = allLives.Find(live => live.TicketNumber == item.Id);

                SeatType seat;
                if (radVip.Checked)
                {
                    seat = SeatType.VIP;
                }
                else if (radStand.Checked)
                {
                    seat = SeatType.站;
                }
                else
                {
                    seat = SeatType.普;
                }

                string postUrl = "https://shop.48.cn/TOrder/add";
                string postData = string.Format("id={0}&num={1}&seattype={2}&brand_id={3}&r={4}&choose_times_end=-1",
                    l.TicketNumber, this.txtNumber.Value, Convert.ToInt32(seat),
                    l.Group.GroupId, r.NextDouble()
                );
                
                // 购票请求
                Task.Factory.StartNew(() =>
                {
                    this.btnBuyOne.Enabled = false;
                    return util.POST(postUrl, cc, postData);
                }).ContinueWith(t =>
                {                   
                    if (t.Result.IndexOf("success") > -1 ||
                        (t.Result.IndexOf("下单申请成功") > -1 && DateTime.Now.Hour == 7)
                    )
                    {
                        this.buyOK = true;
                        MessageBox.Show("购买成功！");
                        timerSubRequest.Stop();
                    }
                    else if (t.Result.IndexOf("下单申请成功") > -1 && DateTime.Now.Hour >= 8)
                    {                                               
                        // 子请求
                        timerSubRequest.Tick += (s, e) => {
                            string childRequestUrl = string.Format("https://shop.48.cn/TOrder/tickCheck?id={0}&r={1}" , l.TicketNumber , r.NextDouble() );
                            util.GET(childRequestUrl, cc);
                        };
                        timerSubRequest.Start();
                    }    
                    this.btnBuyOne.Enabled = true;
                });

            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show("请先选择需要购买的门票！！");
            }
        }

        // 发送购买请求
        private void btnBuyOne_Click(object sender, EventArgs e)
        {
            if (this.buyOK)
            {
                return;
            }

            // 自动重复购买勾上了
            if ( this.chkAutoRepeat.Checked )
            {
                this.timerAutoBuyRepeatfully.Start();
                this.btnBuyOne.Enabled = false;
            }
            else
            {
                this.timerAutoBuyRepeatfully.Stop();
                this.btnBuyOne.Enabled = true;
            }

            buy();            
            
        }


        /// <summary>
        /// 切换选择票务后，读取并展示该票务的详情
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ddlTicket_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBoxListItem item = this.ddlTicket.SelectedItem as ComboBoxListItem;
            Live l = allLives.Find(live => live.TicketNumber == item.Id);

            // MessageBox.Show(l.ToString());
            string liveMessage = string.Format("开始时间：{0} \n\n场次类型:{1}\n\n详情：{2}",
                l.LiveDetail.StartTime, l.LiveDetail.LiveType, l.LiveDetail.Detail);

            // 可选没有库存的票
            this.radVip.BackColor = l.LiveDetail.RemainingTickets[0] ? Color.Green : Color.Red ;
            this.radStand.BackColor = l.LiveDetail.RemainingTickets[1] ? Color.Green : Color.Red;
            this.radNormal.BackColor = l.LiveDetail.RemainingTickets[2] ? Color.Green : Color.Red;


            this.lblDetail.Text = liveMessage;
        }


        private void btnBuyGoods_Click(object sender, EventArgs e)
        {
            var score = "800";
            string url = this.txtGoodsId.Text.Trim();      
            string goodsId = string.Empty;
            if( url.Length<=5)
            {
                goodsId = url;
            }
            else
            {
                goodsId = url.Substring( url.LastIndexOf("/")+1,   url.Length - url.LastIndexOf("/")-1);
            }

            if ( ! new Regex("\\d{1,7}").IsMatch( goodsId ) )
            {   // url格式不正确
                return;
            }

            // url : https://shop.48.cn/goods/item/5573

            // 1) post : https://shop.48.cn/order/limited
            //          goods_id=5845&attr_id=0&num=1&isLoadCardNum=true&brand_id=0

            //   {"ExtensionData":{},"HasError":false,"ErrorCode":"","Message":"ok","ReturnObject":null}

            // 2) post: https://shop.48.cn/order/buy
            //          num=1&donatenum=0&goods_id=5845&attr_id=0
            //          响应核对订单信息页面
            //  读取  <div data-id="55123" data-province="10" data-city="107" data-address="xxxxxxxxxx" class="addresslist ck_add_un">

            // 3) post ：https://shop.48.cn/order/getFare
            //          province=10&city=107&lgs_id=12
            //  {"ExtensionData":null,"rl_id":0,"region_id":0,"lgs_id":0,"fare":12,"add_fare":2}

            //    提交订单
            // 4) post: https://shop.48.cn/Order/BuySaveForGive  AddressID=55666&goods_amount=0&shipping_fee=0&goods_id=5145&attr_id=0&num=1&sumPayPrice=0.00&is_inv=false&lgs_id=12&integral=1000&invoice_type=1&invoice_title=%E8%AE%B8%E5%B4%87&invoice_price=0&CompanyName=&TaxpayerID=&CompanyAddress=&CompanyPhone=&CompanyBankOfDeposit=&CompanyBankNo=&rule_goodslist_content=&radom_rule_goodslist_content=&remark=&IsIntegralOffsetFreight=false&r=0.5816156735958098
            // {"ExtensionData":{},"HasError":false,"ErrorCode":"","Message":"","ReturnObject":"https://pay.48.cn//Bank/OAuth/181031-1-100596?s=YmJnSjJOd1p0UDQ9"}

            // 5) get : https://pay.48.cn//Bank/OAuth/181031-1-100596?s=YmJnSjJOd1p0UDQ9


            #region duplicated , jump over
            // 第一个线程
            //Task.Factory.StartNew(() =>
            //{
            //    util.POST("https://shop.48.cn/order/limited", cc, "goods_id=" + goodsId + "&attr_id=0&num=1&isLoadCardNum=true&brand_id=0");
            //});
            #endregion


            // 第二个线程
            Task.Factory.StartNew( ()=>
            {
                return util.POST("https://shop.48.cn/order/buy", cc, "num=1&donatenum=0&goods_id=" + goodsId + "&attr_id=0");
            }).ContinueWith(t =>
            {
                // get score
                var reg1 = new Regex("<span class=\"sp_list_5 lh100 kb pink\">\\d{1,10}</span>");
                var scoreSpan = reg1.Match(t.Result).ToString();
                var reg2 = new Regex(">\\d{1,10}<");
                var scoreString = reg2.Match(scoreSpan).ToString();
                score = scoreString.Substring(1, scoreString.Length - 2);
                //MessageBox.Show( score );

                // get data-id
                Regex regExp = new Regex("<div data-id=\"\\d{1,7}\" data-province=\"\\d{1,3}\" data-city=\"\\d{1,6}\" data-address=\".{5,200}\" class=\"addresslist ck_add_un\">");
                string data = regExp.Match(t.Result).ToString();
                var regExp2 = new Regex("data-id=\"\\d{1,7}\"");
                data = regExp2.Match(data).ToString();
                var dataId = data.Substring(data.IndexOf("\"") + 1, data.Length - data.IndexOf("\"") - 2);

                return dataId;
            }).ContinueWith( t=> {
                var postData = string.Format("AddressID={0}&goods_amount=0&shipping_fee=0&goods_id={1}&attr_id=0&num=1&sumPayPrice=0.00&is_inv=false&lgs_id=12&integral={2}&invoice_type=1&invoice_title=%E8%AE%B8%E5%B4%87&invoice_price=0&CompanyName=&TaxpayerID=&CompanyAddress=&CompanyPhone=&CompanyBankOfDeposit=&CompanyBankNo=&rule_goodslist_content=&radom_rule_goodslist_content=&remark=&IsIntegralOffsetFreight=false&r={3}" , t.Result , goodsId , score , r.NextDouble() );

                var buyResult = util.POST("https://shop.48.cn/Order/BuySaveForGive", cc, postData);

                // {"ExtensionData":{},"HasError":false,"ErrorCode":"","Message":"","ReturnObject":"https://pay.48.cn//Bank/OAuth/181031-1-100600?s=YmJnSjJOd1p0UDQ9"}
                // {"ExtensionData":{},"HasError":true,"ErrorCode":"143105","Message":"商品库存不足","ReturnObject":null}
                if ( buyResult.IndexOf("HasError\":false") > -1)
                {
                    MessageBox.Show("购买成功！");
                }
                else
                {
                    MessageBox.Show("购买失败！\n错误信息：" + buyResult);
                }

            });

        }

        private void timerAutoBuyAtEight_Tick(object sender, EventArgs e)
        {
            var now = DateTime.Now ;
            var eight = new DateTime(
                now.Year, now.Month, now.Day, 20, 0, 0
            );

            var timeSpan = eight - now;

            // 时间到，自动点击购买按钮
            if (chkTimeUpAutoBuy.Checked && timeSpan.TotalSeconds < 0 && login)
            {
                // 购票
                btnBuyOne_Click(null, null);

                // 购冷餐
                btnBuyGoods_Click(null, null);
                // 停止计时器
                this.timerAutoBuyAtEight.Stop();
            }

            var timeStr = timeSpan.ToString(@"hh\:mm\:ss");

            this.lblTimeToEight.Text = timeStr;
        }

        private void timerAutoBuyRepeatfully_Tick(object sender, EventArgs e)
        {
            if (!this.chkAutoRepeat.Checked)
            {
                this.timerAutoBuyRepeatfully.Stop();
                this.btnBuyOne.Enabled = true;
            }
            else
            {
                buyNoAlert();
            }

            
        }

        private void ddlGroup_DrawItem(object sender, DrawItemEventArgs e)
        {
            // MessageBox.Show( e.Index.ToString() );
            ComboBoxListItem item = this.ddlGroup.Items[e.Index] as ComboBoxListItem;

            Color c = item.Color;
            
            Font font = new Font("微软雅黑", 9);
            Rectangle r = new Rectangle( e.Bounds.Left, e.Bounds.Top ,
                e.Bounds.Width, e.Bounds.Height );
            e.DrawBackground();
            e.Graphics.FillRectangle(new SolidBrush(c), r);
            e.Graphics.DrawString( item.Name , font, Brushes.Black, new RectangleF(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height));
            e.DrawFocusRectangle();
        }

        private void ddlTicket_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index== -1)
            {
                return;
            }

            ComboBoxListItem item = this.ddlTicket.Items[e.Index] as ComboBoxListItem;
            Color c = item.Color;           

            Font font = new Font("微软雅黑", 9);
            Rectangle r = new Rectangle(e.Bounds.Left, e.Bounds.Top,
                e.Bounds.Width, e.Bounds.Height);
            e.DrawBackground();
            e.Graphics.FillRectangle(new SolidBrush(c), r);
            e.Graphics.DrawString(item.Name, font, Brushes.Black, new RectangleF(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height));
            e.DrawFocusRectangle();
        }

        private void timerSyncDateTime_Tick(object sender, EventArgs e)
        {
            serverDateTime = DateTimeUtil.GetServerTime();
            timeSpan = serverDateTime - DateTime.Now;

            this.lblTimeSpan.Text = string.Format("当前服务器时间比本机时间{0}{1}秒,10秒后再次同步" ,
               timeSpan.TotalSeconds > 0?"慢":"快" , Math.Abs(timeSpan.TotalSeconds)  );          
        }

        private void timerSubRequest_Tick(object sender, EventArgs e)
        {

        }
    }
}
