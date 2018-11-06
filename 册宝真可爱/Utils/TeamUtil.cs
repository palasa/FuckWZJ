using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 册宝真可爱.Entitys;

namespace 册宝真可爱.Utils
{
    struct TeamUtil
    {
        public static Team S { get { return new Team(0, "S", TeamColor.SII); } }
        public static Team N { get { return new Team(1, "N", TeamColor.NII); } }
        public static Team H { get { return new Team(2, "H", TeamColor.HII); } }
        public static Team SII {get{return new Team(0, "SII", TeamColor.SII);} }
        public static Team NII { get { return new Team(1, "NII", TeamColor.NII); } }
        public static Team HII { get { return new Team(2, "HII", TeamColor.HII); } }
        public static Team X { get { return new Team(3, "X", TeamColor.X); } }
        public static Team XII { get { return new Team(4, "XII", TeamColor.XII); } }
        public static Team FT { get { return new Team(5, "FT", TeamColor.FT); } }
        public static Team B { get { return new Team(6, "B", TeamColor.B); } }
        public static Team E { get { return new Team(7, "E", TeamColor.E); } }
        public static Team J { get { return new Team(8, "J", TeamColor.J); } }
        public static Team G { get { return new Team(9, "G", TeamColor.G); } }
        public static Team NIII { get { return new Team(10, "NIII", TeamColor.NIII); } }
        public static Team Z { get { return new Team(11, "Z", TeamColor.Z); } }
        public static Team SIII { get { return new Team(12, "SIII", TeamColor.SIII); } }
        public static Team HIII { get { return new Team(13, "HIII", TeamColor.HIII); } }
        public static Team C { get { return new Team(14, "C", TeamColor.C); } }
        public static Team K { get { return new Team(15, "K", TeamColor.K); } }

        public static Team Reserve { get { return new Team(999, "预备生", TeamColor.ReserveTeam ); } }

        public static Team Union { get { return new Team(1000, "联合", TeamColor.Unknown ); } }

        public static Team UnKnownTeam { get { return new Team(-1, "UnKnownTeam", TeamColor.Unknown); } }

        public static List<Team> SNH48Teams
        {
            get { return new List<Team> { S, N, H, X, XII, FT }; }
        }

        public static List<Team> BEJ48Teams
        {
            get { return new List<Team> { B, E, J }; }
        }

        public static List<Team> GNZ48Teams
        {
            get { return new List<Team> { G, NIII, Z }; }
        }

        public static List<Team> SHY48Teams
        {
            get { return new List<Team> { SIII, HIII }; }
        }

        public static List<Team> CKG48Teams
        {
            get { return new List<Team> { C, K }; }
        }

        public static List<Team> AllTeams
        {
            get
            {
                return SNH48Teams.Union(BEJ48Teams).Union(GNZ48Teams).Union(SHY48Teams).Union(CKG48Teams).ToList<Team>();
            }
        }
    }
}
