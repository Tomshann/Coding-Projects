import pytest
import reporting

def test_dailyaverage():
    with pytest.raises(Exception):
        reporting.daily_average({},"Harlington","no") 
    assert reporting.daily_average({1},"Harlington","sadasdadasd") == "Pollutant not found"
    #create a days random test data with an average of 9.25
    data = [
        "time,station,no,pm10,pm25",
        "12:00,station1,10,20,30",
        "13:00,station1,15,25,35",
        "12:00,station2,5,10,15",
        "13:00,station2,7,14,21",
        "12:00,station1,10,20,30",
        "13:00,station1,15,25,35",
        "12:00,station2,5,10,15",
        "13:00,station2,7,14,21",
        "12:00,station1,10,20,30",
        "13:00,station1,15,25,35",
        "12:00,station2,5,10,15",
        "13:00,station2,7,14,21",
        "12:00,station1,10,20,30",
        "13:00,station1,15,25,35",
        "12:00,station2,5,10,15",
        "13:00,station2,7,14,21",
        "12:00,station1,10,20,30",
        "13:00,station1,15,25,35",
        "12:00,station2,5,10,15",
        "13:00,station2,7,14,21",
        "12:00,station1,10,20,30",
        "13:00,station1,15,25,35",
        "12:00,station2,5,10,15",
        "13:00,station2,7,14,21",
        "12:00,station1,10,20,30",
        "13:00,station1,15,25,35",
        "12:00,station2,5,10,15",
        "13:00,station2,7,14,21"
    ]
    assert reporting.daily_average(data,"Harlington","no") == ('The daily average for Harlington is: ', [9.25])
def test_daily_median():
    with pytest.raises(Exception):
        reporting.daily_median({},"Harlington","no") 
    assert reporting.daily_median({1},"Harlington","sadasdadasd") == "Pollutant not found"
    data = [
        "time,station,no,pm10,pm25",
        "12:00,station1,10,20,30",
        "13:00,station1,15,25,35",
        "12:00,station2,5,10,15",
        "13:00,station2,7,14,21",
        "12:00,station1,10,20,30",
        "13:00,station1,15,25,35",
        "12:00,station2,5,10,15",
        "13:00,station2,7,14,21",
        "12:00,station1,10,20,30",
        "13:00,station1,15,25,35",
        "12:00,station2,5,10,15",
        "13:00,station2,7,14,21",
        "12:00,station1,10,20,30",
        "13:00,station1,15,25,35",
        "12:00,station2,5,10,15",
        "13:00,station2,7,14,21",
        "12:00,station1,10,20,30",
        "13:00,station1,15,25,35",
        "12:00,station2,5,10,15",
        "13:00,station2,7,14,21",
        "12:00,station1,10,20,30",
        "13:00,station1,15,25,35",
        "12:00,station2,5,10,15",
        "13:00,station2,7,14,21",
        "12:00,station1,10,20,30",
        "13:00,station1,15,25,35",
        "12:00,station2,5,10,15",
        "13:00,station2,7,14,21"
    ]
    assert reporting.daily_median(data,"Harlington","no") == ('The daily median for Harlington:', [8.5])

def test_hourly_average():
    with pytest.raises(Exception):
        reporting.hourly_average({},"Harlington","no") 
    assert reporting.hourly_average({1},"Harlington","sadasdadasd") == "Pollutant not found"
    #creating 2 days of data
    data = [
        "time,station,no,pm10,pm25",
        "12:00,station1,10,20,30",
        "13:00,station1,15,25,35",
        "12:00,station2,5,10,15",
        "13:00,station2,7,14,21",
        "12:00,station1,10,20,30",
        "13:00,station1,15,25,35",
        "12:00,station2,5,10,15",
        "13:00,station2,7,14,21",
        "12:00,station1,10,20,30",
        "13:00,station1,15,25,35",
        "12:00,station2,5,10,15",
        "13:00,station2,7,14,21",
        "12:00,station1,10,20,30",
        "13:00,station1,15,25,35",
        "12:00,station2,5,10,15",
        "13:00,station2,7,14,21",
        "12:00,station1,10,20,30",
        "13:00,station1,15,25,35",
        "12:00,station2,5,10,15",
        "13:00,station2,7,14,21",
        "12:00,station1,10,20,30",
        "13:00,station1,15,25,35",
        "12:00,station2,5,10,15",
        "13:00,station2,7,14,21",
        "12:00,station1,20,20,30",
        "13:00,station1,30,25,35",
        "12:00,station2,10,10,15",
        "13:00,station2,14,14,21",
        "12:00,station1,20,20,30",
        "13:00,station1,30,25,35",
        "12:00,station2,10,10,15",
        "13:00,station2,14,14,21",
        "12:00,station1,20,20,30",
        "13:00,station1,30,25,35",
        "12:00,station2,10,10,15",
        "13:00,station2,14,14,21",
        "12:00,station1,20,20,30",
        "13:00,station1,30,25,35",
        "12:00,station2,10,10,15",
        "13:00,station2,14,14,21",
        "12:00,station1,20,20,30",
        "13:00,station1,30,25,35",
        "12:00,station2,10,10,15",
        "13:00,station2,14,14,21",
        "12:00,station1,20,20,30",
        "13:00,station1,30,25,35",
        "12:00,station2,10,10,15",
        "13:00,station2,14,14,21",
        
        
    ]
    assert reporting.hourly_average(data,"Harlington","no") == ('The hourly average for Harlington:', [15.0, 22.5, 7.5, 10.5, 15.0, 22.5, 7.5, 10.5,15.0, 22.5, 7.5, 10.5, 15.0, 22.5, 7.5, 10.5,15.0, 22.5, 7.5, 10.5, 15.0, 22.5, 7.5, 10.5,])

def test_monthly_average():
    with pytest.raises(Exception):
        reporting.monthly_average({},"Harlington","no") 
    assert reporting.monthly_average({1},"Harlington","sadasdadasd") == "Pollutant not found"
    #creating a small data entry for 1 month
    data = [
        "time,station,no,pm10,pm25",
        "2022-01-01,station1,10,20,30",
        "2022-01-12,station1,20,20,30",
        "2022-01-21,station1,30,20,30",
        "2022-01-28,station1,15,20,30"
    ]
    assert reporting.monthly_average(data,"Harlington","no") == ('The monthly average for Harlington:', [18.75, 'No data', 'No data', 'No data', 'No data', 'No data','No data', 'No data', 'No data', 'No data', 'No data','No data'])

def test_peak_hour_date():
    date = "2022-10-01"
    with pytest.raises(Exception):
        reporting.peak_hour_date({},date,"Harlington","no") 
    assert reporting.peak_hour_date({1},date,"Harlington","sadasdadasd") == "Pollutant not found"
   

    # Test with a few hours data
    data = [
        "date,time,no,pm10,pm25",  
        "2022-12-14,10:00,0.0,10.0,2.5",
        "2022-12-14,11:00,0.0,12.0,3.0",
        "2022-12-14,12:00,0.0,9.0,2.0",
        "2022-12-14,13:00,0.0,7.0,1.5",
    ]
    date = "2022-12-14"
    output = "The peak hour and value for Harlington:", "11:00", 12.0
    assert reporting.peak_hour_date(data, date,"Harlington","pm10") == output

def test_count_missing_data():
    with pytest.raises(Exception):
        reporting.count_missing_data({},"Harlington","no") 
    assert reporting.count_missing_data({1},"Harlington","sadasdadasd") == "Pollutant not found"
    # Test with a few hours data
    data = [
        "date,time,no,pm10,pm25",
        "2022-12-14,10:00,No data,10.0,2.5",
        "2022-12-14,11:00,0.0,12.0,3.0",
        "2022-12-14,12:00,No data,9.0,2.0",
        "2022-12-14,13:00,0.0,7.0,1.5"
    ]
    assert reporting.count_missing_data(data,"harlington","no") == ('the missing data for harlington: ', 2)

def test_fill_missing_data():
    with pytest.raises(Exception):
        reporting.fill_missing_data({},2,"Harlington","no") 
    assert reporting.fill_missing_data({1},2,"Harlington","sadasdadasd") == "Pollutant not found"
    # Test with a few hours data
    data = [
        "date,time,no,pm10,pm25",
        "2022-12-14,10:00,No data,10.0,2.5",
        "2022-12-14,11:00,0.0,12.0,3.0",
        "2022-12-14,12:00,No data,9.0,2.0",
        "2022-12-14,13:00,0.0,7.0,1.5"
    ]
    assert reporting.fill_missing_data(data,200,"harlington","no") == ('The completed data for harlington: ', [200, '0.0', 200, '0.0'])