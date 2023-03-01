import pytest
import intelligence
import numpy as np

def test_find_red_pixels():
    with pytest.raises(Exception):
        intelligence.find_red_pixels("sdadasdsadas") 

def test_find_cyan_pixels():
    with pytest.raises(Exception):
        intelligence.find_cyan_pixels("sdadasdsadas") 

def test_connected_components():
    #testing an array with one connected component
    testing  =  np.zeros((2,2,1))
    testing[0,0] =1
    testing[0,1] =1
    testing[1,0] =1
    assert intelligence.detect_connected_components(testing).all() == testing.all()
    #testing an array with no connected components
    testing  =  np.zeros((2,2,1))
    assert intelligence.detect_connected_components(testing).all() == testing.all()
    #testing an array with two connected component
    testing  =  np.zeros((3,3,1))
    testing[0,0] =1
    testing[1,0] =1
    testing[2,0] =1
    testing[0,2] =1
    testing[1,2] =1
    testing[2,2] =1
    assert intelligence.detect_connected_components(testing).all() == testing.all()

def test_connected_components_sorted():
    """unable to produce suitable tests for this function as it has no returns"""