﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RSFMEdia.StatisProCardFactory.Models;

namespace RSFMEdia.StatisProCardFactory.Business
{
    public class StatisProData
    {
        public static List<SPNumber> NumberConversions = new List<SPNumber>()
        {
            new SPNumber {RealNumber = 1, Number=11, Base8Number=11},
            new SPNumber {RealNumber = 2, Number=12, Base8Number=12},
            new SPNumber {RealNumber = 3, Number=13, Base8Number=13},
            new SPNumber {RealNumber = 4, Number=14, Base8Number=14},
            new SPNumber {RealNumber = 5, Number=15, Base8Number=15},
            new SPNumber {RealNumber = 6, Number=16, Base8Number=16},
            new SPNumber {RealNumber = 7, Number=17, Base8Number=17},
            new SPNumber {RealNumber = 8, Number=18, Base8Number=18},
            new SPNumber {RealNumber = 9, Number=19, Base8Number=21},
            new SPNumber {RealNumber = 10, Number=20, Base8Number=22},
            new SPNumber {RealNumber = 11, Number=21, Base8Number=23},
            new SPNumber {RealNumber = 12, Number=22, Base8Number=24},
            new SPNumber {RealNumber = 13, Number=23, Base8Number=25},
            new SPNumber {RealNumber = 14, Number=24, Base8Number=26},
            new SPNumber {RealNumber = 15, Number=25, Base8Number=27},
            new SPNumber {RealNumber = 16, Number=26, Base8Number=28},
            new SPNumber {RealNumber = 17, Number=27, Base8Number=31},
            new SPNumber {RealNumber = 18, Number=28, Base8Number=32},
            new SPNumber {RealNumber = 19, Number=29, Base8Number=33},
            new SPNumber {RealNumber = 20, Number=30, Base8Number=34},
            new SPNumber {RealNumber = 21, Number=31, Base8Number=35},
            new SPNumber {RealNumber = 22, Number=32, Base8Number=36},
            new SPNumber {RealNumber = 23, Number=33, Base8Number=37},
            new SPNumber {RealNumber = 24, Number=34, Base8Number=38},
            new SPNumber {RealNumber = 25, Number=35, Base8Number=41},
            new SPNumber {RealNumber = 26, Number=36, Base8Number=42},
            new SPNumber {RealNumber = 27, Number=37, Base8Number=43},
            new SPNumber {RealNumber = 28, Number=38, Base8Number=44},
            new SPNumber {RealNumber = 29, Number=39, Base8Number=45},
            new SPNumber {RealNumber = 30, Number=40, Base8Number=46},
            new SPNumber {RealNumber = 31, Number=41, Base8Number=47},
            new SPNumber {RealNumber = 32, Number=42, Base8Number=48},
            new SPNumber {RealNumber = 33, Number=43, Base8Number=51},
            new SPNumber {RealNumber = 34, Number=44, Base8Number=52},
            new SPNumber {RealNumber = 35, Number=45, Base8Number=53},
            new SPNumber {RealNumber = 36, Number=46, Base8Number=54},
            new SPNumber {RealNumber = 37, Number=47, Base8Number=55},
            new SPNumber {RealNumber = 38, Number=48, Base8Number=56},
            new SPNumber {RealNumber = 39, Number=49, Base8Number=57},
            new SPNumber {RealNumber = 40, Number=50, Base8Number=58},
            new SPNumber {RealNumber = 41, Number=51, Base8Number=61},
            new SPNumber {RealNumber = 42, Number=52, Base8Number=62},
            new SPNumber {RealNumber = 43, Number=53, Base8Number=63},
            new SPNumber {RealNumber = 44, Number=54, Base8Number=64},
            new SPNumber {RealNumber = 45, Number=55, Base8Number=65},
            new SPNumber {RealNumber = 46, Number=56, Base8Number=66},
            new SPNumber {RealNumber = 47, Number=57, Base8Number=67},
            new SPNumber {RealNumber = 48, Number=58, Base8Number=68},
            new SPNumber {RealNumber = 49, Number=59, Base8Number=71},
            new SPNumber {RealNumber = 50, Number=60, Base8Number=72},
            new SPNumber {RealNumber = 51, Number=61, Base8Number=73},
            new SPNumber {RealNumber = 52, Number=62, Base8Number=74},
            new SPNumber {RealNumber = 53, Number=63, Base8Number=75},
            new SPNumber {RealNumber = 54, Number=64, Base8Number=76},
            new SPNumber {RealNumber = 55, Number=65, Base8Number=77},
            new SPNumber {RealNumber = 56, Number=66, Base8Number=78},
            new SPNumber {RealNumber = 57, Number=67, Base8Number=81},
            new SPNumber {RealNumber = 58, Number=68, Base8Number=82},
            new SPNumber {RealNumber = 59, Number=69, Base8Number=83},
            new SPNumber {RealNumber = 60, Number=70, Base8Number=84},
            new SPNumber {RealNumber = 61, Number=71, Base8Number=85},
            new SPNumber {RealNumber = 62, Number=72, Base8Number=86},
            new SPNumber {RealNumber = 63, Number=73, Base8Number=87},
            new SPNumber {RealNumber = 64, Number=74, Base8Number=88}
        };

        public static List<OutfieldArmLookup> OutfieldArmRatings = new List<OutfieldArmLookup>()
        {
            new OutfieldArmLookup {Assists = 1, T ="T5", Description="Very strong arm"},
            new OutfieldArmLookup {T ="T4", Description="Very good arm"},
            new OutfieldArmLookup {T = "T3", Description="Average arm"},
            new OutfieldArmLookup {T ="T2", Description="Poor arm"}
        };

        public static List<CatcherArmLookup> CatcherArmRatings = new List<CatcherArmLookup>()
        {
            new CatcherArmLookup {CaughtStealingPct = 1, T ="A", Description="Very strong arm"},
            new CatcherArmLookup {CaughtStealingPct = 1, T = "B", Description="Average arm"},
            new CatcherArmLookup {CaughtStealingPct = 0, T = "C", Description="Poor arm"}
        };

        public static List<SPRating> SPRatings = new List<SPRating>()
        {
            new SPRating { StolenBases = 30, SP = "A" },
            new SPRating { StolenBases = 20, SP = "B" },
            new SPRating { StolenBases = 10, SP = "C" },
            new SPRating { StolenBases = 1, SP = "D" },
            new SPRating { StolenBases = 0, SP = "E" }
        };

        public static List<SACRating> SACRatings = new List<SACRating>()
        {
            new SACRating { SacrificeHits = 8, SAC = "AA" },
            new SACRating { SacrificeHits = 5, SAC = "BB" },
            new SACRating { SacrificeHits = 2, SAC= "CC" },
            new SACRating { SacrificeHits = 0, SAC = "DD" }
        };

        public static List<INJRating> INJRatings = new List<INJRating>()
        {
            new INJRating { GamesPlayed = 162, INJ = "0" },
            new INJRating { GamesPlayed = 161, INJ = "1" },
            new INJRating { GamesPlayed = 159, INJ = "2" },
            new INJRating { GamesPlayed = 157, INJ = "3" },
            new INJRating { GamesPlayed = 152, INJ = "4" },
            new INJRating { GamesPlayed = 142, INJ = "5" },
            new INJRating { GamesPlayed = 132, INJ = "6" },
            new INJRating { GamesPlayed = 81, INJ = "7" },
            new INJRating { GamesPlayed = 0, INJ = "8" },
        };

        public static List<ErrorRatingLookup> ErrorRatingsOF = new List<ErrorRatingLookup>()
        {
            new ErrorRatingLookup { FldPctHigh = .999M, FldPctLow = .990M, E = "1" },
            new ErrorRatingLookup { FldPctHigh = .989M, FldPctLow = .980M, E = "2" },
            new ErrorRatingLookup { FldPctHigh = .979M, FldPctLow = .970M, E = "3" },
            new ErrorRatingLookup { FldPctHigh = .969M, FldPctLow = .960M, E = "4" },
            new ErrorRatingLookup { FldPctHigh = .959M, FldPctLow = .950M, E = "5" },
            new ErrorRatingLookup { FldPctHigh = .949M, FldPctLow = .940M, E = "6" },
            new ErrorRatingLookup { FldPctHigh = .939M, FldPctLow = .930M, E = "7" },
            new ErrorRatingLookup { FldPctHigh = .929M, FldPctLow = .920M, E = "8" },
            new ErrorRatingLookup { FldPctHigh = .919M, FldPctLow = .910M, E = "9" },
            new ErrorRatingLookup { FldPctHigh = .909M, FldPctLow = .000M, E = "10" }
        };

        public static List<ErrorRatingLookup> ErrorRatings3B = new List<ErrorRatingLookup>()
        {
            new ErrorRatingLookup { FldPctHigh = .999M, FldPctLow = .986M, E = "1" },
            new ErrorRatingLookup { FldPctHigh = .985M, FldPctLow = .976M, E = "2" },
            new ErrorRatingLookup { FldPctHigh = .975M, FldPctLow = .966M, E = "3" },
            new ErrorRatingLookup { FldPctHigh = .965M, FldPctLow = .956M, E = "4" },
            new ErrorRatingLookup { FldPctHigh = .955M, FldPctLow = .946M, E = "5" },
            new ErrorRatingLookup { FldPctHigh = .945M, FldPctLow = .936M, E = "6" },
            new ErrorRatingLookup { FldPctHigh = .935M, FldPctLow = .926M, E = "7" },
            new ErrorRatingLookup { FldPctHigh = .925M, FldPctLow = .916M, E = "8" },
            new ErrorRatingLookup { FldPctHigh = .915M, FldPctLow = .906M, E = "9" },
            new ErrorRatingLookup { FldPctHigh = .905M, FldPctLow = .000M, E = "10" }
        };

        public static List<ErrorRatingLookup> ErrorRatings1B = new List<ErrorRatingLookup>()
        {
            new ErrorRatingLookup { FldPctHigh = .999M, FldPctLow = .995M, E = "1" },
            new ErrorRatingLookup { FldPctHigh = .994M, FldPctLow = .990M, E = "2" },
            new ErrorRatingLookup { FldPctHigh = .989M, FldPctLow = .985M, E = "3" },
            new ErrorRatingLookup { FldPctHigh = .984M, FldPctLow = .980M, E = "4" },
            new ErrorRatingLookup { FldPctHigh = .979M, FldPctLow = .975M, E = "5" },
            new ErrorRatingLookup { FldPctHigh = .974M, FldPctLow = .970M, E = "6" },
            new ErrorRatingLookup { FldPctHigh = .969M, FldPctLow = .965M, E = "7" },
            new ErrorRatingLookup { FldPctHigh = .964M, FldPctLow = .960M, E = "8" },
            new ErrorRatingLookup { FldPctHigh = .959M, FldPctLow = .955M, E = "9" },
            new ErrorRatingLookup { FldPctHigh = .954M, FldPctLow = .000M, E = "10" }
        };

        public static List<ErrorRatingLookup> ErrorRatingsIF = new List<ErrorRatingLookup>()
        {
            new ErrorRatingLookup { FldPctHigh = .999M, FldPctLow = .985M, E = "1" },
            new ErrorRatingLookup { FldPctHigh = .984M, FldPctLow = .975M, E = "2" },
            new ErrorRatingLookup { FldPctHigh = .974M, FldPctLow = .965M, E = "3" },
            new ErrorRatingLookup { FldPctHigh = .964M, FldPctLow = .955M, E = "4" },
            new ErrorRatingLookup { FldPctHigh = .954M, FldPctLow = .945M, E = "5" },
            new ErrorRatingLookup { FldPctHigh = .944M, FldPctLow = .935M, E = "6" },
            new ErrorRatingLookup { FldPctHigh = .934M, FldPctLow = .925M, E = "7" },
            new ErrorRatingLookup { FldPctHigh = .924M, FldPctLow = .915M, E = "8" },
            new ErrorRatingLookup { FldPctHigh = .914M, FldPctLow = .905M, E = "9" },
            new ErrorRatingLookup { FldPctHigh = .904M, FldPctLow = .000M, E = "10" }
        };
    }
}