is_perfect_square(N):-
    S is floor(sqrt(N)),
    S * S =:= N.

generator3(N):-
    between(1000, 1000000, X),
    is_perfect_square(X),
    N is X.
    

x_generator3( N ) :-
	x_generator3_loop(
		[ 1024 , 9409 , 23716 , 51529
        , 123904 , 185761 , 868624 , 962361
        , 982081 , 1000000 ] , 0 , N ) .
x_generator3_loop( [] , C , C ) .
x_generator3_loop( [ T | TS ] , C , N ) :-
  generator3( T ),
  C1 is C + 1,
  x_generator3_loop( TS , C1 , N ).
x_generator3_loop( [ _ | TS ] , C , N ):-
	x_generator3_loop( TS , C , N ).

all_different([]).
all_different([H|T]) :-
    \+ member(H, T),  
    all_different(T).

	
all_different_digits(N) :-
    number_chars(N, Digits),
    all_different(Digits).
 

last_digit_equal_to_number_of_digits(N) :-
    number_chars(N, Digits),
    length(Digits, Length),
    last(Digits, LastDigit),
    atom_number(LastDigit, Length).
 

last_but_one_digit_odd(N) :-
    number_chars(N, Digits),
    length(Digits, Length),
    Length > 2,  
    Index is Length - 1,
    nth1(Index, Digits, LastButOneDigitChar),
    atom_number(LastButOneDigitChar, LastButOneDigit),
    LastButOneDigit mod 2 =:= 1.
 

has_zero_digit(N) :-
    number_chars(N, Digits),
    member('0', Digits).
 

digits_multiples_of_first(N) :-
    number_chars(N, Digits),
    length(Digits, Length),
    Length > 2, 
    nth1(1, Digits, FirstDigit),
    atom_number(FirstDigit, First),
    nth1(2, Digits, SecondDigit),
    atom_number(SecondDigit, Second),
    nth1(3, Digits, ThirdDigit),
    atom_number(ThirdDigit, Third),
    nth1(Length, Digits, LastButOneDigit),
    atom_number(LastButOneDigit, LastButOne),
    Second \= 0,  % Ensure First is not 0
    Second mod First =:= 0,
    Third mod First =:= 0,
    LastButOne mod First =:= 0.
 

tester3(N) :-
    all_different_digits(N),
    last_digit_equal_to_number_of_digits(N),
    last_but_one_digit_odd(N),
    has_zero_digit(N),
    digits_multiples_of_first(N).

x_tester3( N ):-
	x_tester3_loop(
      [ 123056 , 128036 , 139076 , 142076
      , 148056 , 159076 , 173096 , 189036
      , 193056 , 198076 ] , 0 , N ) .
x_tester3_loop( [] , C , C ) .
x_tester3_loop( [ T | TS ] , C , N ):-
  tester3( T ) ,
  C1 is C + 1 ,
  x_tester3_loop( TS , C1 , N ) .
x_tester3_loop( [ _ | TS ] , C , N ):-
	x_tester3_loop( TS , C , N ) .

main :-
	generator3( N ) , tester3( N ) , write( N ) .

