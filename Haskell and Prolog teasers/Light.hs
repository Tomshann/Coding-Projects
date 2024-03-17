import Data.List


segmentCount :: Int -> Int
segmentCount x
    | x `elem` [0, 6] = 6
    | x `elem` [1] = 2
    | x `elem` [2, 3, 5] = 5
    | x `elem` [4] = 4
    | x `elem` [7] = 3
    | x `elem` [8] = 7
    | x `elem` [9] = 6
    | otherwise = 0


prime::(Int,Int,Int,Int)->Bool
prime (a1,a2,a3,a4) 
    |total<=1 = False
    |total == 2 = True
    |otherwise = primeChecker total 2
    where
    total = totalCount(a1,a2,a3,a4)


primeChecker :: Int->Int-> Bool
primeChecker n d 
    | d> (n `div` 2) = True
    | n `mod` d == 0 = False
    |otherwise = primeChecker n (d+1)


totalCount :: (Int,Int,Int,Int) -> Int
totalCount (a1,a2,a3,a4)=
  segmentCount(a1 `mod` 10) +
  segmentCount(a2 `mod` 10)+
  segmentCount(a3 `mod`10)+
  segmentCount(a4 `mod` 10)+
  segmentCount(a1`div`10)+
  segmentCount(a2`div`10)+
  segmentCount(a3`div`10)+
  segmentCount(a4`div`10)

uniqueDigits :: (Int, Int, Int, Int) -> Bool
uniqueDigits (a1, a2, a3, a4) =
  let digits = concatMap addZeroIfNeeded [a1, a2, a3, a4]
  in length digits == length (nub digits)
  where
    addZeroIfNeeded :: Int -> String
    addZeroIfNeeded x
      | x >= 0 && x <= 9 = '0' : show x
      | otherwise = show x

generator1 ::[(Int,Int,Int,Int)]
generator1 
  = [(a1,a2,a3,a4)
    | a1<-[0..23]
    , a2<-[0..59]
    , a3<-[1..31]
    , a4<-[1..12]
    ]    


tester1 :: (Int, Int, Int, Int) -> Bool
tester1 (a1,a2,a3,a4) =
  uniqueDigits(a1,a2,a3,a4) && prime(a1,a2,a3,a4) && uniqueDigits(a1,a2, (a3+1) ,a4) && prime(a1,a2,(a3+1),a4) &&
    ((totalCount(a1,a2,a3,a4) + totalCount(a1,a2,(a3+1),a4))`div`2) == totalCount(a1',a2',a3',a4)
    where
    a1' = nextHour a1 (a2+1)
    a2' = nextMin (a2+1)
    a3' = nextDay (nextHour a1 a2+1) (nextMin (a2+1)) (a3+1)


nextHour :: Int -> Int -> Int
nextHour h m 
  |h == 23 && m==60 = 0
  |m == 60 = (h+1)
  |otherwise = h

nextMin :: Int -> Int
nextMin m
  | m == 60 =0
  | otherwise = m

nextDay :: Int -> Int -> Int -> Int
nextDay h m d
  | h == 0 && m==0 = (d+1)
  | otherwise = d


x_generator1 :: Int
x_generator1 =
  length [ t | t <- ts , t `elem` g ]
  where
  g = generator1
  ts =
    [ ( 2 ,15 ,14 ,11)
    , ( 4 ,31 ,27 , 9)
    , ( 6 ,47 ,10 , 8)
    , ( 9 , 3 ,23 , 6)
    , (11 ,19 , 6 , 5)
    , (13 ,35 ,19 , 3)
    , (15 ,51 , 2 , 2)
    , (18 , 6 ,16 ,12)
    , (20 ,22 ,29 ,10)
    , (22 ,38 ,11 , 9)
    ]

x_tester1 :: Int
x_tester1 =
  length [ t | t <- ts , tester1 t ]
  where
  ts =
    [ ( 6 ,59 ,17 ,24)
    , ( 6 ,59 ,17 ,34)
    , ( 6 ,59 ,27 ,14)
    , ( 6 ,59 ,27 ,41)
    , ( 8 ,59 ,12 ,46)
    , (16 ,59 , 7 ,24)
    , (16 ,59 , 7 ,42)
    , (16 ,59 , 7 ,43)
    , (16 ,59 ,27 ,40)
    , (18 ,59 , 2 ,46)
    ]


main :: IO()
main = print(filter tester1 generator1)