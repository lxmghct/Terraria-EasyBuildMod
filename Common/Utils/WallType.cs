
namespace EasyBuildMod.Common.Utils
{
    public static partial class WallUtils
    {
        ///<summary>
        ///获取墙壁的掉落物类型
        ///代码源自Terraria.WorldGen的私有方法KillWall_MakeWallDust
        ///</summary>
        public static int KillWall_GetItemDrops(Tile tileCache)
		{
			switch (tileCache.WallType)
			{
			case 237:
				return 4233;
			case 238:
				return 4234;
			case 239:
				return 4235;
			case 240:
				return 4236;
			case 246:
				return 4486;
			case 247:
				return 4487;
			case 248:
				return 4488;
			case 249:
				return 4489;
			case 250:
				return 4490;
			case 251:
				return 4491;
			case 252:
				return 4492;
			case 253:
				return 4493;
			case 254:
				return 4494;
			case 255:
				return 4495;
			case 256:
				return 4496;
			case 257:
				return 4497;
			case 258:
				return 4498;
			case 259:
				return 4499;
			case 260:
				return 4500;
			case 261:
				return 4501;
			case 262:
				return 4502;
			case 263:
				return 4503;
			case 264:
				return 4504;
			case 265:
				return 4505;
			case 266:
				return 4506;
			case 267:
				return 4507;
			case 268:
				return 4508;
			case 269:
				return 4509;
			case 270:
				return 4510;
			case 271:
				return 4511;
			case 274:
				return 4512;
			case 275:
				return 3273;
			case 276:
				return 4513;
			case 277:
				return 4514;
			case 278:
				return 4515;
			case 279:
				return 4516;
			case 280:
				return 4517;
			case 281:
				return 4518;
			case 282:
				return 4519;
			case 283:
				return 4520;
			case 284:
				return 4521;
			case 285:
				return 4522;
			case 286:
				return 4523;
			case 287:
				return 4524;
			case 288:
				return 4525;
			case 289:
				return 4526;
			case 290:
				return 4527;
			case 291:
				return 4528;
			case 292:
				return 4529;
			case 293:
				return 4530;
			case 294:
				return 4531;
			case 295:
				return 4532;
			case 296:
				return 4533;
			case 297:
				return 4534;
			case 298:
				return 4535;
			case 299:
				return 4536;
			case 300:
				return 4537;
			case 301:
				return 4538;
			case 302:
				return 4539;
			case 303:
				return 4540;
			case 304:
				return 3340;
			case 305:
				return 3341;
			case 306:
				return 3342;
			case 307:
				return 3343;
			case 308:
				return 3344;
			case 309:
				return 3345;
			case 310:
				return 3346;
			case 311:
				return 3348;
			case 314:
				return 4647;
			}
			int result = 0;
			if (tileCache.WallType == 168)
			{
				result = 2696;
			}
			if (tileCache.WallType == 169)
			{
				result = 2698;
			}
			if (tileCache.WallType == 226)
			{
				result = 3752;
			}
			if (tileCache.WallType == 227)
			{
				result = 3753;
			}
			if (tileCache.WallType == 228)
			{
				result = 3760;
			}
			if (tileCache.WallType == 229)
			{
				result = 3761;
			}
			if (tileCache.WallType == 230)
			{
				result = 3762;
			}
			if (tileCache.WallType == 142)
			{
				result = 2263;
			}
			if (tileCache.WallType == 143)
			{
				result = 2264;
			}
			if (tileCache.WallType == 144)
			{
				result = 2271;
			}
			if (tileCache.WallType == 149)
			{
				result = 2505;
			}
			if (tileCache.WallType == 150)
			{
				result = 2507;
			}
			if (tileCache.WallType == 151)
			{
				result = 2506;
			}
			if (tileCache.WallType == 152)
			{
				result = 2508;
			}
			if (tileCache.WallType == 245)
			{
				result = 4424;
			}
			if (tileCache.WallType == 315)
			{
				result = 4667;
			}
			if (tileCache.WallType == 1)
			{
				result = 26;
			}
			if (tileCache.WallType == 4)
			{
				result = 93;
			}
			if (tileCache.WallType == 5)
			{
				result = 130;
			}
			if (tileCache.WallType == 6)
			{
				result = 132;
			}
			if (tileCache.WallType == 7)
			{
				result = 135;
			}
			if (tileCache.WallType == 8)
			{
				result = 138;
			}
			if (tileCache.WallType == 9)
			{
				result = 140;
			}
			if (tileCache.WallType == 10)
			{
				result = 142;
			}
			if (tileCache.WallType == 11)
			{
				result = 144;
			}
			if (tileCache.WallType == 12)
			{
				result = 146;
			}
			if (tileCache.WallType == 14)
			{
				result = 330;
			}
			if (tileCache.WallType == 224)
			{
				result = 3472;
			}
			if (tileCache.WallType == 177)
			{
				result = 3067;
			}
			if (tileCache.WallType == 167)
			{
				result = 2691;
			}
			if (tileCache.WallType == 60)
			{
				result = 3584;
			}
			if (tileCache.WallType == 231)
			{
				result = 3952;
			}
			if (tileCache.WallType == 232)
			{
				result = 3954;
			}
			if (tileCache.WallType == 225)
			{
				result = 3751;
			}
			if (tileCache.WallType == 233)
			{
				result = 3956;
			}
			if (tileCache.WallType == 234)
			{
				result = 4052;
			}
			if (tileCache.WallType == 235)
			{
				result = 4053;
			}
			if (tileCache.WallType == 236)
			{
				result = 4140;
			}
			if (tileCache.WallType == 312)
			{
				result = 4565;
			}
			if (tileCache.WallType == 313)
			{
				result = 4548;
			}
			if (tileCache.WallType == 179)
			{
				result = 3083;
			}
			if (tileCache.WallType == 183)
			{
				result = 3082;
			}
			if (tileCache.WallType == 181)
			{
				result = 3089;
			}
			if (tileCache.WallType == 184)
			{
				result = 3088;
			}
			if (tileCache.WallType == 186)
			{
				result = 3238;
			}
			if (tileCache.WallType >= 153 && tileCache.WallType <= 166)
			{
				switch (tileCache.WallType)
				{
				case 153:
					result = 2677;
					break;
				case 154:
					result = 2679;
					break;
				case 155:
					result = 2681;
					break;
				case 156:
					result = 2683;
					break;
				case 157:
					result = 2678;
					break;
				case 158:
					result = 2680;
					break;
				case 159:
					result = 2682;
					break;
				case 160:
					result = 2684;
					break;
				case 161:
					result = 2686;
					break;
				case 162:
					result = 2688;
					break;
				case 163:
					result = 2690;
					break;
				case 164:
					result = 2685;
					break;
				case 165:
					result = 2687;
					break;
				case 166:
					result = 2689;
					break;
				}
			}
			if (tileCache.WallType == 136)
			{
				result = 2169;
			}
			if (tileCache.WallType == 137)
			{
				result = 2170;
			}
			if (tileCache.WallType == 172)
			{
				result = 2788;
			}
			if (tileCache.WallType == 242)
			{
				result = 4279;
			}
			if (tileCache.WallType == 243)
			{
				result = 4280;
			}
			if (tileCache.WallType == 145)
			{
				result = 2333;
			}
			if (tileCache.WallType == 16)
			{
				result = 30;
			}
			if (tileCache.WallType == 17)
			{
				result = 135;
			}
			if (tileCache.WallType == 18)
			{
				result = 138;
			}
			if (tileCache.WallType == 19)
			{
				result = 140;
			}
			if (tileCache.WallType == 20)
			{
				result = 330;
			}
			if (tileCache.WallType == 21)
			{
				result = 392;
			}
			if (tileCache.WallType == 86 || tileCache.WallType == 108)
			{
				result = 1126;
			}
			if (tileCache.WallType == 173)
			{
				result = 2789;
			}
			if (tileCache.WallType == 174)
			{
				result = 2790;
			}
			if (tileCache.WallType == 175)
			{
				result = 2791;
			}
			if (tileCache.WallType == 176)
			{
				result = 2861;
			}
			if (tileCache.WallType == 182)
			{
				result = 3101;
			}
			if (tileCache.WallType == 133)
			{
				result = 2158;
			}
			if (tileCache.WallType == 134)
			{
				result = 2159;
			}
			if (tileCache.WallType == 135)
			{
				result = 2160;
			}
			else if (tileCache.WallType == 113)
			{
				result = 1726;
			}
			else if (tileCache.WallType == 114)
			{
				result = 1728;
			}
			else if (tileCache.WallType == 115)
			{
				result = 1730;
			}
			else if (tileCache.WallType == 146)
			{
				result = 2432;
			}
			else if (tileCache.WallType == 147)
			{
				result = 2433;
			}
			else if (tileCache.WallType == 148)
			{
				result = 2434;
			}
			if (tileCache.WallType >= 116 && tileCache.WallType <= 125)
			{
				result = (int)(1948 + tileCache.WallType - 116);
			}
			if (tileCache.WallType >= 126 && tileCache.WallType <= 132)
			{
				result = (int)(2008 + tileCache.WallType - 126);
			}
			if (tileCache.WallType == 22)
			{
				result = 417;
			}
			if (tileCache.WallType == 23)
			{
				result = 418;
			}
			if (tileCache.WallType == 24)
			{
				result = 419;
			}
			if (tileCache.WallType == 25)
			{
				result = 420;
			}
			if (tileCache.WallType == 26)
			{
				result = 421;
			}
			if (tileCache.WallType == 29)
			{
				result = 587;
			}
			if (tileCache.WallType == 30)
			{
				result = 592;
			}
			if (tileCache.WallType == 31)
			{
				result = 595;
			}
			if (tileCache.WallType == 32)
			{
				result = 605;
			}
			if (tileCache.WallType == 33)
			{
				result = 606;
			}
			if (tileCache.WallType == 34)
			{
				result = 608;
			}
			if (tileCache.WallType == 35)
			{
				result = 610;
			}
			if (tileCache.WallType == 36)
			{
				result = 615;
			}
			if (tileCache.WallType == 37)
			{
				result = 616;
			}
			if (tileCache.WallType == 38)
			{
				result = 617;
			}
			if (tileCache.WallType == 39)
			{
				result = 618;
			}
			if (tileCache.WallType == 41)
			{
				result = 622;
			}
			if (tileCache.WallType == 42)
			{
				result = 623;
			}
			if (tileCache.WallType == 43)
			{
				result = 624;
			}
			if (tileCache.WallType == 44)
			{
				result = 663;
			}
			if (tileCache.WallType == 45)
			{
				result = 720;
			}
			if (tileCache.WallType == 46)
			{
				result = 721;
			}
			if (tileCache.WallType == 47)
			{
				result = 722;
			}
			if (tileCache.WallType == 66)
			{
				result = 745;
			}
			if (tileCache.WallType == 67)
			{
				result = 746;
			}
			if (tileCache.WallType == 68)
			{
				result = 747;
			}
			if (tileCache.WallType == 84)
			{
				result = 884;
			}
			if (tileCache.WallType == 72)
			{
				result = 750;
			}
			if (tileCache.WallType == 73)
			{
				result = 752;
			}
			if (tileCache.WallType == 74)
			{
				result = 764;
			}
			if (tileCache.WallType == 85)
			{
				result = 927;
			}
			if (tileCache.WallType == 75)
			{
				result = 768;
			}
			if (tileCache.WallType == 76)
			{
				result = 769;
			}
			if (tileCache.WallType == 77)
			{
				result = 770;
			}
			if (tileCache.WallType == 82)
			{
				result = 825;
			}
			if (tileCache.WallType == 27)
			{
				result = 479;
			}
			if (tileCache.WallType == 106)
			{
				result = 1447;
			}
			if (tileCache.WallType == 107)
			{
				result = 1448;
			}
			if (tileCache.WallType == 109)
			{
				result = 1590;
			}
			if (tileCache.WallType == 110)
			{
				result = 1592;
			}
			if (tileCache.WallType == 111)
			{
				result = 1594;
			}
			if (tileCache.WallType == 78)
			{
				result = 1723;
			}
			if (tileCache.WallType == 87 || tileCache.WallType == 112)
			{
				result = 1102;
			}
			if (tileCache.WallType == 94 || tileCache.WallType == 100)
			{
				result = 1378;
			}
			if (tileCache.WallType == 95 || tileCache.WallType == 101)
			{
				result = 1379;
			}
			if (tileCache.WallType == 96 || tileCache.WallType == 102)
			{
				result = 1380;
			}
			if (tileCache.WallType == 97 || tileCache.WallType == 103)
			{
				result = 1381;
			}
			if (tileCache.WallType == 98 || tileCache.WallType == 104)
			{
				result = 1382;
			}
			if (tileCache.WallType == 99 || tileCache.WallType == 105)
			{
				result = 1383;
			}
			if (tileCache.WallType == 241)
			{
				result = 4260;
			}
			if (tileCache.WallType >= 88 && tileCache.WallType <= 93)
			{
				result = (int)(1267 + tileCache.WallType - 88);
			}
			if (tileCache.WallType >= 138 && tileCache.WallType <= 141)
			{
				result = (int)(2210 + tileCache.WallType - 138);
			}
			return result;
		}
    }
}