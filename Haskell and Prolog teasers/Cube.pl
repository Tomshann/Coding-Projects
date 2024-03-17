is_prime(2).
is_prime(3).
is_prime(P) :-
    P > 3,
    P mod 2 =\= 0,
    \+ has_factor(P, 3).

has_factor(N, I) :-
    N mod I =:= 0.
has_factor(N, I) :-
    I * I < N,
    I2 is I + 2,
    has_factor(N, I2).


concat_digits([], 0).
concat_digits([H|T], Result) :-
    length([H|T], Len),
    Len =< 4,  
    atomic_list_concat([H|T], '', Num),
    atom_number(Num, Result),
    is_prime(Result).


runs(4, Runs) :-
    Digits = [9,8,7,6,5,4,3,2,1,0],
    permutation(Digits, PermutedDigits),
    partition_runs(PermutedDigits, Runs),
    length(Runs, 4).
runs(5, Runs) :-
    Digits = [9,8,7,6,5,4,3,2,1,0],
    permutation(Digits, PermutedDigits),
    partition_runs(PermutedDigits, Runs),
    length(Runs, 5).

runs(6, Runs) :-
    Digits = [9,8,7,6,5,4,3,2,1,0],
    permutation(Digits, PermutedDigits),
    partition_runs(PermutedDigits, Runs),
    length(Runs, 6).
partition_runs([], []).
partition_runs(List, [Run|Runs]) :-
    append(Run, Rest, List),
    Run \== [],
    Run = [First|_], 
    First \== 0,     
    concat_digits(Run, _),
    partition_runs(Rest, Runs).

generator4(Seq) :-
    (runs(4, Seq);runs(5, Seq) ; runs(6, Seq)),
    maplist(concat_digits, Seq, _).
 

x_generator4(N) :-
    x_generator4_loop(
        [
            [[9,6,7],[4,0,1],[2,8,3],[5]],
            [[9,8,3],[6,0,1],[5],[4,7],[2]],
            [[9,8,3],[6,7],[4,2,0,1],[5]],
            [[9,8,5,1],[2],[4,3],[6,0,7]],
            [[9,8,5,1],[2],[3],[6,0,4,7]],
            [[9,8,5,1],[2],[7],[4,6,0,3]],
            [[8,9],[7],[6,0,1],[2,5,4,3]],
            [[8,9],[7],[5,6,3],[4,0,2,1]],
            [[8,9],[5],[4,7],[6,0,1],[3],[2]],
            [[3],[5],[6,0,7],[2],[4,1],[8,9]]
        ],
        0,
        N
    ).

x_generator4_loop([], C, C).
x_generator4_loop([T|TS], C, N) :-
    generator4(T),
    C1 is C + 1,
    x_generator4_loop(TS, C1, N).
x_generator4_loop([_|TS], C, N) :-
    x_generator4_loop(TS, C, N).



is_cube(X) :-
    X >= 0,
    R is round(X**(1/3)),
    R**3 =:= X.


can_form_cubes(Lists) :-
    flatten(Lists, FlatList),
    can_form_cubes_helper(FlatList, []).


can_form_cubes_helper([], []).


can_form_cubes_helper([X|Xs], Acc) :-
    append(Acc, [X], Temp),
    can_form_cubes_helper(Xs, Temp).

can_form_cubes_helper([X|Xs], Acc) :-
    length(Acc, Len),
    (Len =< 4 ; Len == 0),
    append(Acc, [X], Temp),
    is_cube_number(Temp),
    can_form_cubes_helper(Xs, []).


is_cube_number(List) :-
    list_to_number(List, Number),
    is_cube(Number).


list_to_number(Digits, Number) :-
    list_to_number_helper(Digits, 0, Number).

list_to_number_helper([], Acc, Acc).
list_to_number_helper([D|Digits], Acc, Number) :-
    NewAcc is Acc * 10 + D,
    list_to_number_helper(Digits, NewAcc, Number).

tester4(Lists) :-
    remove_smallest(Lists, WithoutSmallest),
    arrange_decreasing(WithoutSmallest, Decreasing),
    can_form_cubes(Decreasing).

remove_smallest(Lists, WithoutSmallest) :-
    select(Min, Lists, Rest),
    list_to_number(Min, MinNumber),
    \+ (member(Sublist, Rest), list_to_number(Sublist, SublistNumber), SublistNumber < MinNumber),
    WithoutSmallest = Rest.

arrange_decreasing(Lists, Result) :-
    predsort(compare_lists, Lists, Result).

compare_lists(Order, List1, List2) :-
    list_to_number(List1, Num1),
    list_to_number(List2, Num2),
    compare(Order, Num2, Num1).


sum_list([], 0).
sum_list([X|Xs], Sum) :-
    sum_list(Xs, Sum1),
    Sum is X + Sum1.

sublist(Sub, List):-
    append(_, SubSuffix, List),
    append(Sub, _, SubSuffix).

x_tester4( N ):-
	x_tester4_loop(
        [[[8,2,7],[6,1],[5,3],[4,0,9]]
        ,[[8,2,7],[6,1],[4,0,9],[5,3]]
        ,[[8,2,7],[5,3],[6,1],[4,0,9]]
        ,[[8,2,7],[4,0,9],[6,1],[5,3]]
        ,[[6,1],[8,2,7],[4 ,0 ,9],[5 ,3]]
        ,[[6,1],[4,0,9],[5,3],[8 ,2 ,7]]
        ,[[5,3],[6,1],[4,0,9],[8,2,7]]
        ,[[5,3],[4,0,9],[6,1],[8,2,7]]
        ,[[4,0,9],[5,3],[8,2,7],[6,1]]
        ,[[4,0,9],[8,2,7],[6,1],[5,3]]],0,N).
x_tester4_loop([],C,C).
x_tester4_loop([ T | TS ],C,N):-
	tester4(T),
	C1 is C + 1,
	x_tester4_loop( TS , C1 , N ).
x_tester4_loop( [ _ | TS ] , C , N ):-
	x_tester4_loop( TS , C , N ).

main:-
	generator4(XS), tester4(XS), write(XS).
