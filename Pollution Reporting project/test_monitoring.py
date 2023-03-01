import pytest
import monitoring


def test_species_information():
    """cannot create any unit tests for this function"""

def test_peak_pollution():
    """cannot test as the function returns nothing"""

def test_live_update():
    """cannot create a unit test for this function"""

def test_monthly_monitoring_index():
    with pytest.raises(Exception):
        monitoring.monthly_monitoring_index()
    with pytest.raises(Exception):
        monitoring.monthly_monitoring_index("MY1",2022,19)
    with pytest.raises(Exception):
        monitoring.monthly_monitoring_index("MY1",2027,12)
    with pytest.raises(Exception):
        monitoring.monthly_monitoring_index("adasdasdas",2022,12)