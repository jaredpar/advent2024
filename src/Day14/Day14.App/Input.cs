using Advent.Util;

namespace Day14;

public sealed class Input
{
    public const string Test = """
        p=0,4 v=3,-3
        p=6,3 v=-1,-3
        p=10,3 v=-1,2
        p=2,0 v=2,-1
        p=0,0 v=1,3
        p=3,0 v=-2,-2
        p=7,6 v=-1,-3
        p=3,0 v=-1,-2
        p=9,3 v=2,3
        p=7,3 v=-1,2
        p=2,4 v=2,-3
        p=9,5 v=-3,-3
        """;

    public const string Real = """
p=24,25 v=-48,-26
p=7,8 v=-96,-2
p=7,80 v=-66,22
p=5,18 v=25,-98
p=45,67 v=26,90
p=54,71 v=3,67
p=62,66 v=-5,81
p=5,82 v=-7,-45
p=66,89 v=93,-43
p=70,51 v=33,-7
p=75,59 v=-20,-77
p=66,40 v=93,55
p=32,79 v=79,45
p=99,13 v=-18,50
p=13,68 v=-43,-53
p=84,85 v=-69,-65
p=37,84 v=11,-57
p=28,10 v=19,-93
p=78,82 v=-56,36
p=20,69 v=-3,-62
p=39,78 v=27,-1
p=51,87 v=-32,-17
p=90,26 v=20,66
p=35,89 v=-11,20
p=71,2 v=-80,92
p=41,40 v=-64,-30
p=38,8 v=-71,54
p=72,58 v=36,-80
p=62,97 v=52,83
p=96,74 v=90,-23
p=76,75 v=-43,-9
p=35,95 v=74,13
p=90,17 v=99,6
p=61,26 v=17,81
p=43,71 v=-43,-51
p=6,18 v=-62,-9
p=37,62 v=-23,-11
p=60,97 v=36,-64
p=54,63 v=-23,-95
p=76,85 v=24,-4
p=38,54 v=-38,-95
p=48,18 v=52,-49
p=45,36 v=-75,-4
p=31,87 v=64,50
p=4,87 v=68,9
p=25,40 v=99,53
p=74,18 v=-73,-71
p=5,22 v=76,65
p=66,12 v=96,-64
p=20,71 v=68,-3
p=3,20 v=4,-77
p=27,43 v=49,55
p=25,70 v=-52,-84
p=90,64 v=39,52
p=32,69 v=82,88
p=2,97 v=-78,76
p=56,6 v=-71,-27
p=91,31 v=84,-41
p=25,12 v=-91,-51
p=7,43 v=-11,59
p=3,55 v=-6,-44
p=83,102 v=9,-76
p=54,40 v=-94,5
p=3,77 v=80,45
p=32,6 v=3,-35
p=14,34 v=-74,-41
p=16,30 v=-21,-86
p=34,71 v=-75,-62
p=79,11 v=67,-10
p=80,11 v=61,9
p=14,84 v=-59,-83
p=73,66 v=-56,3
p=26,61 v=41,-70
p=45,35 v=-97,40
p=84,39 v=-99,55
p=95,50 v=-66,-56
p=17,35 v=-33,-74
p=33,51 v=4,-22
p=6,77 v=-49,-45
p=9,61 v=28,85
p=14,91 v=-70,-12
p=88,73 v=49,-14
p=73,39 v=-16,73
p=68,83 v=25,60
p=3,31 v=83,62
p=31,102 v=30,-49
p=29,29 v=45,-23
p=47,37 v=97,26
p=35,46 v=87,39
p=13,36 v=-74,-37
p=81,33 v=81,-17
p=6,20 v=-14,43
p=94,41 v=89,-72
p=55,44 v=-91,95
p=92,87 v=-17,64
p=54,79 v=-57,-58
p=53,49 v=-19,-84
p=25,21 v=56,-82
p=82,53 v=51,-85
p=75,27 v=69,-4
p=21,87 v=61,-6
p=6,63 v=-74,-77
p=20,4 v=89,-33
p=21,25 v=-78,62
p=24,0 v=-74,43
p=34,86 v=-43,74
p=72,83 v=-35,85
p=47,17 v=41,87
p=3,73 v=-77,-36
p=98,96 v=-73,75
p=66,93 v=-26,20
p=48,79 v=56,-69
p=91,89 v=-47,9
p=49,11 v=96,-47
p=33,4 v=-86,-16
p=76,45 v=-46,3
p=12,28 v=-40,36
p=64,99 v=-79,-83
p=19,83 v=-10,-3
p=87,57 v=84,-33
p=47,69 v=-64,-58
p=56,9 v=33,-60
p=98,94 v=-14,-25
p=60,59 v=-1,-41
p=18,91 v=-93,-85
p=24,21 v=98,-85
p=51,83 v=-23,45
p=12,41 v=-41,-34
p=8,86 v=-55,-50
p=23,48 v=-11,73
p=46,24 v=-4,-75
p=12,82 v=-6,-47
p=78,37 v=-16,-55
p=13,59 v=68,-66
p=63,100 v=44,83
p=99,66 v=31,-65
p=21,97 v=17,-7
p=1,101 v=91,-90
p=16,74 v=90,8
p=15,102 v=98,-9
p=31,34 v=12,91
p=49,65 v=-8,96
p=48,62 v=-41,-58
p=57,13 v=-72,61
p=82,30 v=-69,47
p=31,21 v=41,-44
p=25,93 v=-30,-69
p=33,45 v=4,-96
p=57,15 v=59,10
p=6,74 v=61,-43
p=9,43 v=-64,51
p=69,67 v=10,-51
p=44,93 v=60,93
p=39,77 v=94,-39
p=38,86 v=86,12
p=43,98 v=26,75
p=64,49 v=-87,-84
p=13,64 v=42,30
p=69,91 v=-39,-91
p=83,100 v=-12,61
p=28,66 v=-62,-27
p=15,90 v=-3,-46
p=0,42 v=27,18
p=56,99 v=-24,-67
p=70,68 v=-61,74
p=7,8 v=-70,35
p=5,100 v=16,-13
p=83,49 v=-22,73
p=63,18 v=64,-56
p=78,84 v=28,-57
p=89,39 v=36,26
p=72,31 v=-80,51
p=72,88 v=8,70
p=29,8 v=34,65
p=36,11 v=-86,39
p=16,27 v=12,-52
p=63,63 v=59,63
p=1,4 v=-21,-79
p=95,86 v=-81,-79
p=30,27 v=90,21
p=17,40 v=81,-5
p=47,24 v=47,93
p=4,23 v=31,-49
p=61,34 v=-42,-78
p=34,61 v=-62,44
p=48,18 v=-12,-97
p=32,81 v=-74,-75
p=61,15 v=96,-98
p=8,86 v=87,-54
p=26,95 v=-63,71
p=94,61 v=13,48
p=26,101 v=94,-57
p=24,102 v=4,2
p=83,56 v=-56,44
p=96,37 v=91,-8
p=60,43 v=-18,5
p=93,68 v=92,1
p=79,57 v=-9,77
p=65,68 v=-16,-51
p=26,28 v=-44,-80
p=39,22 v=-75,-23
p=90,0 v=-73,83
p=66,88 v=10,75
p=61,55 v=-87,52
p=43,2 v=45,68
p=85,25 v=-91,-12
p=14,79 v=-50,-20
p=32,98 v=22,21
p=85,59 v=74,-5
p=4,50 v=-14,8
p=99,85 v=35,-28
p=76,80 v=-2,64
p=49,36 v=-8,14
p=60,65 v=-12,67
p=4,84 v=-98,-82
p=0,92 v=-74,-50
p=88,94 v=26,36
p=20,37 v=-7,-8
p=81,28 v=21,-59
p=95,33 v=-39,36
p=26,45 v=-86,23
p=82,19 v=2,-12
p=85,60 v=32,-44
p=5,60 v=79,10
p=53,33 v=-12,62
p=40,79 v=-71,-47
p=75,31 v=-95,95
p=43,2 v=41,-86
p=17,86 v=-81,82
p=10,15 v=-31,46
p=7,74 v=-25,89
p=69,8 v=-61,32
p=82,65 v=-39,74
p=73,101 v=-12,-79
p=51,9 v=93,-16
p=95,56 v=13,15
p=96,67 v=34,29
p=19,91 v=-31,89
p=2,43 v=-96,-55
p=68,60 v=17,-91
p=17,86 v=8,-43
p=5,95 v=16,71
p=49,20 v=37,21
p=6,67 v=-40,96
p=47,95 v=-32,-76
p=45,71 v=-81,2
p=46,31 v=-34,-89
p=49,17 v=-79,-97
p=66,82 v=18,-95
p=69,86 v=81,-21
p=5,87 v=-10,-21
p=84,81 v=47,97
p=89,9 v=13,-60
p=34,15 v=-67,-38
p=51,46 v=-28,-91
p=94,99 v=-21,-35
p=15,20 v=3,48
p=26,72 v=-32,13
p=80,5 v=-43,-20
p=64,82 v=-49,-75
p=56,58 v=-94,81
p=29,86 v=79,16
p=98,60 v=-36,4
p=23,47 v=-37,77
p=48,66 v=63,78
p=48,92 v=-97,74
p=58,86 v=85,27
p=99,85 v=57,97
p=98,53 v=-28,-25
p=72,44 v=-48,31
p=35,67 v=75,30
p=22,11 v=38,13
p=95,41 v=-85,36
p=3,55 v=-85,-66
p=50,57 v=-94,11
p=58,2 v=-42,-64
p=45,3 v=-97,10
p=1,30 v=97,-31
p=75,68 v=13,-58
p=79,101 v=62,-98
p=20,26 v=83,25
p=49,4 v=25,-16
p=46,54 v=89,7
p=86,42 v=-43,-81
p=6,3 v=-99,-5
p=74,50 v=-61,22
p=40,13 v=-38,-57
p=5,54 v=-5,-65
p=55,66 v=10,-25
p=52,82 v=-55,-28
p=70,18 v=-68,-49
p=54,10 v=-38,-16
p=79,35 v=54,-45
p=95,64 v=80,6
p=88,62 v=-56,78
p=65,28 v=-39,43
p=69,29 v=-35,-78
p=68,99 v=-5,79
p=37,22 v=30,-49
p=98,55 v=-92,-84
p=3,1 v=-10,-64
p=56,60 v=49,26
p=38,25 v=-56,91
p=93,22 v=46,87
p=97,11 v=13,-86
p=16,15 v=23,76
p=34,58 v=45,15
p=20,59 v=-12,72
p=30,78 v=-25,50
p=61,59 v=-53,37
p=33,2 v=75,-24
p=36,5 v=81,43
p=90,93 v=-10,50
p=60,74 v=14,96
p=56,40 v=-56,96
p=79,6 v=77,-71
p=87,64 v=-2,-62
p=25,66 v=64,-47
p=4,13 v=-66,54
p=47,57 v=67,59
p=39,64 v=90,-88
p=81,68 v=-73,52
p=59,36 v=-42,-89
p=0,4 v=14,83
p=20,5 v=-67,-9
p=100,45 v=20,-44
p=85,27 v=54,-48
p=58,54 v=-16,-11
p=71,4 v=-54,42
p=22,98 v=83,-46
p=32,7 v=-26,32
p=33,52 v=37,-62
p=82,33 v=-28,14
p=90,11 v=-88,-97
p=39,79 v=52,45
p=60,15 v=70,-79
p=3,38 v=-70,-29
p=10,80 v=27,-10
p=22,22 v=-89,7
p=23,29 v=-74,49
p=45,34 v=26,51
p=59,63 v=-3,41
p=9,28 v=-82,89
p=18,42 v=-10,-67
p=2,80 v=-3,-80
p=94,73 v=13,89
p=89,73 v=-50,-40
p=22,85 v=71,-38
p=20,99 v=52,-10
p=40,89 v=52,27
p=47,99 v=-18,59
p=71,55 v=25,-47
p=69,102 v=-31,-64
p=67,43 v=-91,44
p=79,27 v=69,-72
p=43,53 v=89,22
p=59,30 v=26,-46
p=53,54 v=37,-33
p=72,11 v=-80,-27
p=56,63 v=33,-14
p=53,61 v=24,86
p=40,77 v=-17,-66
p=88,88 v=53,33
p=40,82 v=56,-76
p=16,2 v=60,-94
p=17,83 v=-78,-3
p=16,99 v=-44,13
p=88,19 v=-73,40
p=61,16 v=36,-30
p=1,90 v=-21,-80
p=65,92 v=-95,-30
p=100,98 v=24,31
p=45,54 v=-42,30
p=87,60 v=56,-57
p=97,43 v=75,-96
p=54,64 v=3,69
p=73,29 v=-5,84
p=69,5 v=-99,-27
p=18,8 v=98,94
p=9,4 v=92,61
p=69,50 v=38,34
p=9,52 v=-85,74
p=33,16 v=34,-86
p=38,68 v=15,45
p=93,82 v=25,17
p=22,34 v=6,-51
p=40,81 v=79,-6
p=62,20 v=23,86
p=2,21 v=43,-60
p=19,79 v=-74,38
p=70,3 v=-20,-81
p=57,66 v=-4,-22
p=54,36 v=65,-30
p=48,83 v=-60,-43
p=71,41 v=92,-56
p=90,66 v=-77,-62
p=65,15 v=-24,-79
p=49,48 v=-53,81
p=41,15 v=71,-49
p=59,58 v=83,18
p=27,84 v=-38,64
p=94,34 v=2,36
p=12,34 v=-55,-30
p=64,40 v=-27,29
p=74,28 v=-91,-63
p=81,86 v=-77,-10
p=83,26 v=32,47
p=20,44 v=-63,-96
p=1,48 v=-51,-11
p=69,18 v=-5,-82
p=63,18 v=16,-28
p=88,1 v=-2,46
p=80,44 v=2,33
p=10,35 v=72,10
p=79,35 v=45,-72
p=6,13 v=-18,3
p=40,43 v=41,-4
p=100,18 v=-51,-93
p=71,54 v=94,37
p=4,93 v=50,97
p=9,56 v=76,-77
p=89,38 v=-50,92
p=96,31 v=35,58
p=73,11 v=96,-86
p=36,67 v=-60,27
p=44,77 v=-82,71
p=67,53 v=96,61
p=14,82 v=72,42
p=96,14 v=65,98
p=91,8 v=78,-72
p=44,80 v=-22,-67
p=47,59 v=-75,48
p=90,52 v=-65,-3
p=10,41 v=-29,-70
p=57,90 v=-75,13
p=42,43 v=67,-85
p=51,72 v=33,79
p=33,87 v=60,56
p=93,55 v=-77,-44
p=31,29 v=64,-19
p=91,81 v=21,86
p=100,99 v=-66,-24
p=68,90 v=29,23
p=43,25 v=-6,-49
p=62,37 v=-98,-74
p=57,11 v=97,-83
p=89,85 v=74,14
p=29,18 v=48,-13
p=84,92 v=-43,-93
p=33,5 v=19,94
p=2,85 v=-58,12
p=18,95 v=-41,42
p=75,59 v=34,91
p=0,56 v=-51,-58
p=85,10 v=-91,-37
p=64,20 v=-42,-23
p=28,30 v=-27,7
p=18,46 v=-96,73
p=33,93 v=-93,-53
p=29,64 v=30,-29
p=65,53 v=-42,15
p=26,92 v=11,62
p=69,34 v=-99,-4
p=44,15 v=-94,-64
p=24,42 v=-22,88
p=37,8 v=41,87
p=22,77 v=-54,-54
p=9,13 v=-18,85
p=90,97 v=46,36
p=37,61 v=64,93
p=96,78 v=80,-47
p=92,62 v=6,74
p=19,20 v=-44,-23
p=63,43 v=-16,-4
p=85,0 v=-73,-64
p=37,53 v=-11,-81
p=28,55 v=11,-40
p=77,22 v=-72,-67
p=88,86 v=47,60
p=43,50 v=-19,-95
p=46,28 v=11,3
p=16,5 v=28,66
p=85,85 v=-36,-98
p=95,15 v=9,17
p=46,70 v=-64,82
p=24,49 v=38,-84
p=94,5 v=-24,-83
p=59,73 v=-98,49
p=13,75 v=72,12
p=68,27 v=-57,-5
p=13,71 v=-55,-84
p=57,12 v=-68,28
p=21,90 v=-45,16
p=38,4 v=-93,21
p=66,96 v=-72,-13
p=34,95 v=-41,-90
p=85,39 v=-18,-30
p=3,94 v=9,97
p=89,12 v=5,-67
p=44,58 v=-4,-62
""";
}
