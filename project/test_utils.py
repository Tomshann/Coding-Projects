import pytest
from utils import sumvalues,maxvalue,minvalue,meannvalue,countvalue



def test_sumvalues():
    assert sumvalues([1,2,3]) == 6
    assert sumvalues([]) == 0
    with pytest.raises(Exception):
        sumvalues(['a','b'])

def test_maxvalue():
    assert maxvalue([1,2,18,3,2,5]) ==18
    assert maxvalue([3.1,2,1,18.7]) ==18.7
    assert maxvalue(['c','b']) == 'c'
    with pytest.raises(Exception):
        maxvalue([])

def test_minvalue():
    assert minvalue([1,2,18,3,2,5]) ==1
    assert minvalue([3,0.1,2,1,18.7]) ==0.1
    assert minvalue(['c','b']) == 'b'
    with pytest.raises(Exception):
        maxvalue([])

def test_meannvalue():
    assert meannvalue([10,15,10,15]) ==12.5
    assert meannvalue([0.1,0.2]) == 0.15
    with pytest.raises(Exception):
        meannvalue([])
    with pytest.raises(Exception):
        meannvalue(['a','b'])

def test_countvalue():
    assert countvalue([1,2,3,1,1],1) == 3
    assert countvalue([],'') == 0
    assert countvalue(['a','b'],'a') == 1 