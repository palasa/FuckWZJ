using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace 册宝真可爱.Utils
{
    static class EventUtil
    {

        #region 清除事件绑定的函数

        /// <summary>

        /// 清除事件绑定的函数

        /// </summary>

        /// <param name="objectHasEvents">拥有事件的实例</param>

        /// <param name="eventName">事件名称</param>

        public static void ClearAllEvents(object objectHasEvents, string eventName)

        {

            if (objectHasEvents == null)

            {

                return;

            }

            try

            {

                EventInfo[] events = objectHasEvents.GetType().GetEvents(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

                if (events == null || events.Length < 1)

                {

                    return;

                }

                for (int i = 0; i < events.Length; i++)

                {

                    EventInfo ei = events[i];

                    if (ei.Name == eventName)

                    {

                        FieldInfo fi = ei.DeclaringType.GetField(eventName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

                        if (fi != null)

                        {

                            fi.SetValue(objectHasEvents, null);

                        }

                        break;

                    }

                }

            }

            catch

            {

            }

        }

        #endregion

    }
}

