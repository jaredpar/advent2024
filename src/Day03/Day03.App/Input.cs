using Advent.Util;

namespace Day03;

public sealed class Input
{
    public const string Test = "xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))";

    public const string Test2 = "xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5)";

    public const string Real = """
        from()why()?mul(603,692)({select()}] )]-(mul(387,685)who()mul(28,717)who()]where()what()mul(486,768)]where()$mul(280,932)select()&'?~$mul(306,553)mul(272,821)&mul(547,513)) mul(514,132)when(121,319)who()mul(718,581):-!mul(210,910)}why()from()from()what(),!how()>mul(934,601)-(*@mul(975,495)when()mul(503,843)?mul(550,120)+mul(554,332)(who()+%],,{* mul(748,391)} <@'}mul(287,771)mul(805,862)[mul(899,214)$!~@what(513,928)?mul(677,473)}how()mul(21,309)?why()mul(106,356)when()!mul(614,290)$#>,>(!)&]mul(813,264)-] +mul(333,889)+/$}mul(307,370)[?mul(293,832)who()~why()]how()^>select()]don't()<,'mul(942,587)why()}what()&]-? (!mul(74,836)(,when()what() {*(mul(860,687)mul(50,589)mul(70,389)<{how()/where()]'mul(703,164)/>mul(421,905){/)^]mul(951,314)when()why()mul(958,595)when()]+#)@!!;[do()mul(704,757)#who()%+-mul(914,316)>!?&/@*mul(180,886)>)*mul(471,519)?*where()how(280,479)who()mul(552,129)&>why()($}]mul(361,533)!< }mul(809,768)%why()*}?*}what()!mul(55,163)#$select()how()mul(504,457)$:&$&mul(477,739)~] );-#!-^mul(290,284)how()who()&+why()~]!;mul(817,543)from()mul(510,673)~mul(553,851))when()! <how(872,580)mul(656,733)mul(140,422)<{why()#mul(658,570)how()mul(882,811){,!from() -*don't()%why()!what()+;?when()who()how()mul(237,188)<,when()why()-:mul(12,133)$)~}(?mul(997,797)}(>:+<why()(do());why()mul(671,998)!,$'^?'mul(966,42)*/%how();@[mul(568,327)!,&when()^*)?mul(86,18)*[*~/(<when()-[mul(250,764)],+how()mul(437,601)mul(228,210)->/<}what()'-%from(608,924)mul(51,899))who()mul(720,60)where()&<how(241,696)mul(718,852)how()&~from()mul(275,126)don't());mul(649,30);select(709,248)$,%#%{mul(801,547);(:mul(699,209)#what()mul(818,980)[]mul(30,723)~[;~[]mul(992,299)*@]mul(412,593){(}[what()from()*]mul(569,71)why()- where(587,737)^select(67,161)#;how()mul(167,648+, %mul(50,361)%what()mul(163,385)select()(&who()when()'what()]mul(8,70)how()+where(467,556)]%*select()#)(do()((who()who();~@(+(mul(310,850)#'select(870,87)/who()?+}'-mul(68,773)-{/:}who()select(979,845),&/mul(348,554):when()*why()~($)~ mul(255,103)select()<<)}]what()>*{mul)how()where()})who()%&^mul(632,14)>)*don't()select()(why()!mul(510,556) where()}{:when()&mul(497,500)why()do(),who()~]mul(343,705)/:@why()<[from(579,514)how()*mul(167,77)'):>+!:what();mul(441,250)how()]why(273,806)}[what()why()$why()mul(491,462)#>({(who()#/-mul(534,432)~@-'mul/>>who()($@mul(442,24)~&select(),[who() /mul(317,909)from()*![%%~mul(807,603)>;where()when()where()>mul(757,741):*how(781,794))mul(403when()>]how(472,280)~?}mul(170,711)@~what(){~{why()mul(347,151)$-:from()* -)^how()mul(946,614))mul(496,996)!+^-why()why():-<!mul(80,692))}?*]%$mul(211,911)what()]^?mul(617,234)mul(589,250)how(),select()who()when())?~mul(829,42)who()&why()#~mul(157,619)@>:-+where()do(){-,$; #+what()mul(687,385)$</^from()mul(60,316)do()from()&why()#,what()}where()&$mul(491,760)/mul(74,590)-where()@how()>*?%mul(989,55)~from()?#@where(){from()^what(478,489)do()mul(572,540;why(212,904)<#<mul(579,378)mul(872,838)where(27,803)%;who()>@;~>mul(900,593)[+@{$#how()mul(406,49) where()]@$}(where()what()%mul(712,667)
        #]>from()}:^:why()mul(257,615)@'@[-!-,mul(381,780)how()mul(848,35&who(889,624){?mul(486,721)-*what(342,748)mul(660who()+]%?^what()mul(368,85)+?how();+from()#mulwhy()!how()!mul(21,287)),-+/<'(@mul(680,378)from()+what()@:}+~:<mul(441,96)when(302,268); why()? mul&<>+where()!how()#*mul(755,80)%mul(889^[how())what()$mul(781,598),+:;#'mul(788,253)< mul(131,148)<select(724,259)mul(668,371) ~}/mul(818,401)(mul(404,912)+!)}>!)how()mul(485,939):^[] @mul(401,246-}('^+#how()mul(58,198)@{*when()*~select()from()>mul(703,690)~ mul(210,596)@-mul(89,722)mul(64,727)?why()(mul(319,520)mul(174,955)mul(946,77)'why()- {~+ mul(672,214)mul(809,877)#/how()>~&from()~>mul%~mul(428,30)who()#)where()@when()'mul(928,351)([:^<*}-mul(61,385)#;mul(742,584)<]#-&mul(321,543)+^what()*where();^)from()mul(448,52)/?who()>select()mul(133,834)$mulhow()!where()'#)mul(760,90)mul(899,586)^]<when(305,812)where()mul(38,119)how(841,224)<mul(491,943)*>[where())-mul(352,440)$@(,from()mul(476,125+^from()$/mul(34,660)mul(144,354)who()#^mul(849,172)?;:&:what()%}{>mul(309,477)-why() ^select(),)who()select()mul(491,355);{>how(){[@how()do()~-[what()/)when()>''mul(815,427)mul(538,327)%when()mul(390,965)^')!{::who(){@mul(8,973)who()mul(56,54)what(163,182)?where()$>?,>+*don't()'%when()mul(461,711)+--(where()@, +)mul(523,517)&!mul(27,506)-@+mul(797,6)(who()}mul(243,573)*:</ when()from()why()from()mul(90,879)*[/$do()--})mul(401,598)(mul'*who()mul(724,291)% >where()>why()<]):mul(680,263)!(mul(96,910)@&>who()!why()}<mul(965,945)what()&-'%what()where()'!,mul(181,561)mul(923,14)mul(456,561)//why(),[how()>{mul(548,279)]*(mul(801,596)from()~'[when(),^}-&mul(79,50)where()who():mul(512,820) >}$mul(743,399)how(),when()<why()@+( &mul(790,161);+from(){->^$mul>>[@how()[$)mul(134,216)''mul(596,615):]>~why()&< ]>mul(509,208)select()*:&,:]${mul*:?*from()when(): mul(553,269)how()>&<;(},]where()mul(692,816)$ how()'>;when()don't()what()@what()/;]~^mul(585,546)[mul(280,948)-%mul(404,914)from()select()(^mul(110,946):#why()+&]mul(422,904)^}:%-(mul(513,623)%(!from()mul(981,173)<^who()<> mul(6,379)}$*''who()?{mul(979,885)!what()( how()who()>mul(123,654)how()]select()~)~*%,do()how()&'from()@/from(831,136)mul(273,764)#select()'from(661,437)[:mul(334,108)who(417,697)select()&#mul(863,899)'$}what()^ [);mul(202,611)@%how()&'%#mul(124,666)-*<]mul(405,735)}@[,'^{; mul(39,967)when()'+'/?how()select()>don't()?%%^#+mul(624,72)*mul(232,300) ~+{@where()+{mul(636] why()mul(367,706)from()from()&#!;]:(select()do()/<,where(349,951)mul(276,893)mul(139,18) )when()what()[what()*mul(859,550);mul(971,708)) +who()from(621,931)(($!!mul(856,817)select(),*mul(432,421)^mul(380,571)??{,$when()$why(){mul>/:#-where()when()%how()@what()mul(474,342)!who()):}@how()mul(467,667);mul(31,334)mul(883,979)why()select()/who()[select()!~/~do()mul(161,220)*:what()mul(83,659)~!}^$(why()where()what()select()mul(365,786),when()#{^?why());how()mul(530,814):],how()mul(467,765){[@mul(386,260~who(){mul(798,565)what()#who()]why(), <)mul(115,336)select()}(+what()~^why()'~mul(883,729)!@?;)):&mul(397,957)mul(80,44)?^from()what():(mul(992,682)!@]~why()mul(653,545)when()<,mul(349,559)
        @{how()where()mul(132,764)where()@?]<[:)do()mul(934,299)!how();from(219,458)who()'how()where()mul(448,152)!: >^why()~&what(959,826)mul(421,331)mul(537,76)?<-mul(549,349)@~[!}%$how()*mul(662,422)when()!/^^'#how()!mul(370,635)what():)when()select(424,921)*mul(403,199)where()[}mul(510,374)(what()%mul(356,60)$+when()$mul(743,924)mul(317,382)-*from(253,395)from()^:who()<'mul(692,182)where()*when()mul(743,58)mul(703,870)where()what(74,21)mul(480,28)+what()!&$/?mul(711,746)-::how()why()+%${mul(869,811)how(),){/$<!{mul(941,318)][]don't()(mul(308,634)* (-when()-+ {mul(37,658)from()what()'/'mul(198,2)?who(850,232)&mul(705,593):%when()^,mul(875,559)&who()^^when()how(858,132)'{do(){#{why()#how()]who(502,965)@mul(967,80)mul<-mul(563,131)[[how()#mul(291,212what()(-where()#who()how()(who()/:mul(359,178) ( ;how()-mul(901,273)when()who(394,245)~[~mul(953,398)*$who()^!mul(352,107)why()-~what()who()(/!mul(948,136)((!mul(79,746); ~why()[#$don't()who()from()?who()select(){!,mul(40,449)how()-$mul(66,684)+@mul(991,550)-don't()how()/*&%mul(446,183)}%~(,mul(123,316)]~ when()%mul(139,526)where()-]$%mul(811,973)]+@who()!<%what()}mul(396,530)^ (!{! when()mul(453,475)@$mul(193,617):~where()#;'&^>why()do()who()select()}why()[who()mul(935,566):&~select()<@who()@><mul(588,764)]{']<&;+mul(876,480)/ ?don't()&who()'mul(803,175)mul(574,807)from()-*when()mul(382,480)!<when()^from()mul(761,397)~what()mul(67,293<+how(678,534)^-&~;:-mul(961,982)mul(936,157)}(?where()}*%}mul(885,176)select()select()^where()why(567,551)&why()>(mul(802,524):]who())*[mul(184,293)/+from()[!>'mul(989,102)]$(when()[@don't()?where()^mul(837?!how()@?mul(363,116)how()-select()[where()-'?-mul(451,766)mul(245,879<%<***$[#where(316,862)how()mul(970,700)/do()>*<%}when()mul(80,248):,'@})mul(514,148)why()mul(604,160), @%*$when()@from()mul&$-<?]who()<@:mul(705,20)mul(631,934)from()when()]why()^+from()@mul(745,507)mul(950,240)>^mul(778,375)?select()@<don't()*%how()${+<mul(384,333)mul(829,86)* ]-!##-what()(mul(354,14)]*{why()}+:mul(108,712) select()!why()>select())why(498,51)don't()%@]?(select(),![mul(239,721):@{why()mul(607,190)where()*[when()<'don't()$mul(678,822)>:!,mul(467,171(when()mul(807,110)where()select()mul(242,720)+!>what()%{+,$mul(911&what()}where(818,212)#where()mul(326,766)@'from()#do()mul(556,143)-@when()^/how()^[mul(408,289)mul(576,220@&who())mul(64,259)+]mul(610,521)mul(605,41)@mul(417[what():!+mul(908,353)[mul(396,24)who()mul(91,151)%select()mul(544,343)}[*~&why()mul(695,829)what()^;where()?,[[mul(905,287)};where())*?where()mul(666,591)-;#[}who()mul(671,325);where()%mul(630,789)&;@%}>}'?mul(711,15)} >{{what(948,68)mul(570,962)>mul(513,989)who()':[mul(672,83)-select()what()<;#why()where()don't()mul(458,928)where()/@$how(681,711)mul(573,736)&who(105,88)>,what(257,757):;)mul(720,176)^/@{how()>+$+when()mul(930,133)how()<%[}why()-why()}mul(33,761)+mul(47,200)mul(146,123){select()(select()/%;,mul(18,995)select()/from()how()%mul(383,881)<[+[mul(240}!where()how():mul(847,979)<when(379,74)from(786,583)~?what()'*)mul(359,138)(select():};}<&;$mul(639,348)}}mul(149,749)&)?)what()from()mul(492&where(83,831)/mul(695,814)+]&~;^from() how()mul(814,851)?mul(48,23)what():( +:%]what():mul(18,789)mul(35,166)),'select()(:mul(152,666)-@when()when()*mul(59,304)$#!/usr/bin/perl&%%how()<#%{mul(700,975)
        },&^from()}:!select()+mul(164&?^mul(937,897)]<mul(496,412)',$what()&<-;+mul(939,943)why()*from()^why()~}mul(875,236)mul(582,429)select()*^<%}~how()%what()mul-{from()^(what() &mul(376,235)%why()~mul(878,480)# from()mul(313,371)@<$&who(417,600)^)/)>mul(726,233)]what():mul(798,926)*]when(){%-})from()mul(133,906)<:$where()@($from()}mul(45,7);/why()<who(){mul(194,192)'$-](mul(753,205))^mul(409,557)?select()mul(640,700^mul(653,642)mul(621,879)}*mul(554&!when()?don't()how()~?>~mul(801where(866,189)mul(176,679)#++:mul(172,913)~,,%select()'<mul(955,545)how()]{;where()';>mul(48,534);;~ -who()<^mul(705,712)*^,mul(232,487)what()-((%what(),what()$mul(228,981),;who()'when()+%[mul(886,441)}%<*,,mul(837,365)-!+',:%-select()mul(7,594);mul(530,424)why()[~/?mul(171,756)@]^*mul(342,328)*where()*;where()<mul(68,782)$#what()&+mul(760,893)when()how()how()when(){&!what(),what(249,135)mul(197,513)select():<^(when()]what()>where()mul(51,137),how()&/[*&mul(994,980)what()^^how()-]mul(161,542)%&why()!+:}mul(854,734)mul(715,965)>#mul(225,21)@{how()~;mul(168,178)%where()/;]-what()mul(625,781*mul(913,156)(?when(581,507)??~-what()'mul(369,928)&(?/,-don't()$mul(901,668){#-how()where()$;?/mul(11,724):{~/&who(923,98)[/>mul(530,998)mul(186,573)$[;%]!>^^)mul(115,810select()!/&;why()mul(314,424))what()$mul(852,503)when()from()mul(521,770)who(802,289),('mul(361,165)why(454,380)&[how()mul(410,359)!when();~when(629,110)why()+,)mul(600,742)%~where(791,133)mul(219,287)mul(931,454)]from(), +<mul(276,461]why()select()?-&mul(923,519)select()%who()select(176,593)what()mul(21,994);+}why(),# }mul(401,769)how()>$'mul(882,113)select()where()]+mul(983,17),where()$%why()select()mul(217,362)mul(692,111)mul(34,17)how():%what()how()]mul(472,633){%mul(324,69)]select()mul(542,365)(why()%?;who()mul(806,779)when()]}?:~mul(946,462)mul(957how()~mul(707,432)>,-*^&mul(477,553)^mul(362,4)why()#]?who()from(934,98)#from()*mul(356,610):who()( +,~:mul(99!when()}?&what()%,~]where()mul(156,709),mul(858,113)how()$how()what()mul(458,358)*)@>$[]mul(388,862)]#don't()~#[how();mul(848,651)*where(741,650))mul(129,5)'@@,mul(153,994)]<when()%mul(622,234)>mul(596,617)-^$+%/+how()mul(863,465),who(765,354)mul(436,109)where()]!@mul(403,366)~''who() {&mul(421,812)when()from()mul(783,846):}-from()'+,mul(406,87)who()!select()mul(138,952)?why() },>select()$mul(118,332){),@~:mul(505,459)%}[<:how(273,57)^>(what()mul(65,551who()(how()-~when()(:what()from()mul(345,236)'mul(892,526)/why()mul(739,975),who()mul(710-*%mul(40,319)?why():mul(919,144)!when()mul(540,77)what()select()mul(527,286)'(^%why()(don't();*who()?who()mul(865,906)$what()+}mul(417,111)what();+mul(877,675[]what()mul(905,57){from()(}<mul(239,849)$?*&(who()~mul(692,812)!how();(select()!](,!mul(161,465)+;${mul(462,987)^#who() !(:mul(637,849)select(){what())select()%don't()/what()+mul(674,134)^*;<}where())-~-mul(833,896)^+mul(423,773)>/who()~>-mul(914,370)where()?&mul(734,186)%!%,:)mul(54,324)mul(238,439)when()what()mul(73,276)[how()[*+where()how()}{mul(505,735)~how()*~select()]+mul(956,708)[!+ %;+what()/why()mul(888,390),!(?^;what()#mul(716,886)
        [mul(980,100:+when()what()<>mul(670,970)where() mul(60,574)+ where()from()>mul(424,922)-what()) };mul(998,698)/~&}++*mul(700,428)mul(711,527)}@'>mul(460,489)?'(/;mul(544,578)+from()who()when()mul(842,707)/mul(548,669)~%: <mul(825,601) --?#where() ~%mul(669,232) !%}} what()don't(),*^,what(947,870)mul(450,236)where()from()~!why()^#mul(724,798)}<where()+who()&-mul(854,601)don't()] }what()who()when()/#]mul(807,181)mul(139,233) )^from()]}-:don't()-(>%!$(mul(637,105)#/how()who()mul(333,88)mul(442,689)~&,:%#mul(142,210) 'when()mul(92,854)mul(967,544):}<%what() {#don't()*?+*{what()>mul(731,150)^/when()what(866,334)mul+&@mul(735,364)when(187,833)^ (+*~mul(508,962)from()select()mul(703,591)mul(448,49) when();from()*mul(214,478)!mul(891,494)mul(745,961)from():select()who()'#where();mul(867,127)<)(^,+*mul(894,207))what()what()&'select()mul(382,824)from()/;} %/*mul(343,494)$+%when()-**mul(658,77)$why()@when()@who()%(where(681,90)>mul(359,733)?what()mul(657,531);#/ $&#mul(94,761)~when()@<+where()*[?mul(730,273)<(' *!#when()'+mul(29,213)<:*{from()>,mul(999,444)@when()where()+-from()do()mul(620,569)why()mul(34,811)mul(934,29)where()>-where()why(),+&)mul-%^@select()!)(<+mul(707,336)$]%@mul(459,769)who()%+what()where():!mul(547,553)mul(554,390)who()#where()from()#>,<[mul(125,257)(!(where()^~-select()mul(297,774)when()where()%when()@mul(919,719)who())?;:%&[who()mul(40,839)}>*;mul(944,123);}when(),)<~]?mul(652,722)why()when()%why()<]mul(193,859)%>mul(379,558)why()mul(231,786)<#']who(){<#mul(748,767)select();mul(15,618)don't()!+{+*what()mul(814,151)when()when()]where()don't():,]from()#%,who()mul(556,60)why()how()what()how();mul(56,682)!,}][where()mul(974,191)!mul(894,70)?&#do()-what()/how()what()?>why(726,902)$;mul(364,892)select()$##]what(956,616)%~)mul(264,763)select()why()mul(663,310)+<what()when(){-what()from()don't()(mul(475,832)mul(476,754)++$from()]why()why()don't()where()$>who(273,991)-mul(97,257)why(){>$who(920,449){>,%}do()*mul(672,685)where();!^)why()(from()%how()mul(384,910),;why()!how():#{'mul(169,774)select()/>!${}mul(843,717)'where()*-select(){&what()$%mul(3,577)+'/!~:<mul(229,886$mul(489,326)*%[%how()mul(669,215) ?;,when()mul(381,222)^}/<<mul(903,770)what()$why(300,252)who()'mul(558,39)${]*mul(452&~;:%when()from()mul(345,575)$% mul(545,777)#~who()#when()~}*):mul(924what();when()!>where(){)@mul(729,710):where())when()%]why()~{$mul(542,202)>select()[<mul(571,693)![&{mul(585,353)[,>how()how()*%<+don't() ^mul(754,460)mul(590,305)mul(959@#]-where()#mul(724,268)>?what())why()who())[ mul(548,465),mul(50,721)when()mul/what()@:;mul(43,189)don't()-(how();!mul(206,946)mul(962,222)//why()$mul(448,884):[~ ^don't()@mul(637,461)>select(905,87)[!how()(why()~mul(281,216)^;-when()/how()-&%;mul(577,722)!%{(!?how()+@)mul(269,575) select()@(>)&}from(),mul(80why()who()-!]when(347,788)>from()-'when()don't()'what();&where()mul<>^~> where()-who()who()mul(89,415)<$>>when()where(){select()mul(945,109#[#how()],how()'/-*mul(874,712) }-}#]*mul(368,562)<*}what()where()?mul(691,657)who()what()'; :&mul(25,126)from()!*when()^(>from()do()how(264,492)?@@[)mul(648,619)>where()%'~%@}&mul(949,194)*mul(486,964))why()}&^<)mul(556,688)@#,+-$*(what()mul(81,110)!?:@%?;what()mul(897,336)how()]!mul(842,431)mul(927,669)]&(how()* when()$mul(84,909)who()+select(){mul(666,542)why()mul(148,609)
        #mul(55,264)?!^+)when()what()mul(332,605)where(){what()?what()mul(721,480)& #@mul(61,304),@from()@how()#mul(496,506)select()$mul(826,26){/',how()][,~where()mul(773,845)how()from()^mul%(*mul(239,751)*who()&^how()}mul(971,568);-when()#+&why(){,<mul(5,463) &when()from()what()mul(729}mul(916,267)<[*,&how()/?how()don't()mul(660,591)&where()(?don't()from()#}how()/-select()how(434,293)/how()mul(814,315)@,mul(375,352)~who()mul(604,641)how(){*mul(697,582)*<$~#$+mul(785,263),]mul(996,281{,>>>;who()>where()do()[<@how()$@]where()?from()mul(619,593)@#:when()-where()[[why()+mul(53,745):;?(#mul(167*from()'*){-how()mul(746,677)?}:from()select()!^:%]mul(410,746)!$* <from()!,[&mul(845,464)$&mul(896,813)where()mul(54,238)//-(mul(883,723what()^&^&]*^#?#mul(563,741){what()select()from()mul(980,799)^$!how()mul(917,887)+when()~mul(584,634)mul(800,808),(+mul(110,742) )mul(794,827)from()mul(728,673):from()<mul(974,575)what()!)[how()@-(mul(932,342)don't(),/why()}{[/[<mul(878,49)(*&}+ {^where()mul(8,170){)[where()-{who()mul(943,97)[<when()@what()${}mulselect(601,221);%?*where()mul(979,454)}>:[-mul(355,228)} select()@ mul(968,91)/~<(who()//]mul(923,647)(,'mul(697,603)!select(),select()select()?how()mul(609,195)why(664,970)why(),^<[don't()select()/?mul>from()/',why()how()mul(833,431)&}+%<mul(574,75)%from()mul(434,592)how(968,108))#+*^mul(402,713)!^-mul(840,750)&who()when(),-%]]!who()mul(378,549)^what(){when()'?#>#mul(924,387)mul(245,807)from()where()where():mul(866,528)[^from()<what())mul(888,545);mul(230,653))~'when()from()mul(390,618){mul(176,749)''{%how()<do()when()when()how(800,720){( -*'mul(236,243)how()>who()how()select()where()what() mul(610,589)/ !&,{who()mul(81,246)#mul(591,208)}^+$where()select()when()mul(936,143)<< >select():>:@mul(349,372)$^! ]}?('do()when()/mul(42,24) -?who()@mul(501,520){@what(869,966)why()select()&mul(435,922)&>@from(134,495)select())<?mul(649,430)when()?&,%why(119,306)?/]do();from()from()#select())^[mul(493,435)?why()!!+^&^ 'mul(284,380)from()?select()/!+when()+$&mul(206,195)who()[what()what()from():!%mul(732,958);}{'{,mul(436,176)who()mul(816,609)%%don't()why(828,659)!!mul(764,105),%why()~^who()who()mul(320,728) {why()who()}<~mul(57,498)+~-(:why()~*mul(564,176)>where()@from()!]'mul(955,305)*mul(39,915)how()what()mul(484,347)&<!where()how()*mul(210,126)[;>select() ?~[?)don't()!>?^?#who()mul(30,374)@]>$when()!?where()]select()mul(770,206)mul(260,165)-~/^mul(980,877)){where()from())mul(556,133))@&;who(257,213)where()*;^{mul(381,791);]select(821,109)+select()<  why()(do()mul(763,606):<#[>;*(*how()don't()$>how()(#{mul(898,960)]from()how()^why()from()/:mul(932,119)@%){from();mul(926,30)#;mul(90,54)/^<mul(682,330)what()do()>~'#}/mul(665,248)mul(483,311)~+:,(how()mul(824,825)(}<why()(,*who()(why()don't()who();^<&;++mul(34,885),mul(295,956)mul(277,622) select()$%{mul(20,610)'#when()]~ >mul(342,735)from()+/&what()mul(903,919) ()%from()'(why()mul(556,22)@#what()!mul(544,701)when()*>+'$$&'[mul(811,773)-,~~mul(701,85)::-/-do():when(318,3)how()&%who()mul(759,372)>+why(),/)~mul(796,407){mul(101,955)select(){mul(429,479)who()]->}@mul(174,416);when()!what(): '[{-mul(909,460)@&who()^/;@!mul(517,830)mul(809,577)},#why()how()+ how()&mul(813,555)/( from()'*
        """;
}
