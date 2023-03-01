
def daily_average(data,monitoring_station:str, pollutant:str):
    """ 
    This function takes in the data , monitioring station and the pollutant type that is wanted to be averaged,
    It uses these parameters to search through the recorded data and calculate the daily averages for the last year and returns a list of all the averages.

    variables
    ----------
    linecount  this is used to count the lines in the file so that each days recordings can be identified
    data  the list of data values from the monitoring station
    location  this is used to find the position in the list of data where the pollution number is
    sum  this is the sum of all the hourly pollutions
    recordings  this is the number of data recordings that have been iterated through
    average_list  this is the container for the daily averages
    pollutant  this is the type of pollutant data that is wanting to be collected
    monitoring_station  this is the area that the pollution data is to be collected from
    filereader  this is the container that points to the csv file
    ----------
    returns:
    average_list  which contains all of the calculated daily averages
    """

    linecount = 0 
    location = 0
    sum = 0
    recordings =0
    average_list = []
    if pollutant == "no":  #these 3 if statements help to determine the location of the correct data column to be retrieved
        location = 2
    elif pollutant == "pm10":
        location = 3
    elif pollutant == "pm25":
        location = 4
    else:
        return("Pollutant not found")
        
    
    if(data == {} or data == []):
        raise Exception("data set was empty")
        
        
    for row in data: #iterates through each row in the list
        if linecount == 0:  #identfies the first row as the headings and moves on without performing any operations to data
            linecount +=1
            continue
        elif linecount %25 == 0: #identifies that a whole 24hours of recordings has been added to the sum variable then calculates the average
            if recordings != 0:#Checks to ensure that there is no division by zero due to no data for the day
                average_list.append(sum/recordings) # appends the daily average to the list of averages   
            else:
                average_list.append("No data for the day") #appends No data if there is no data for the day
            sum = 0
            recordings = 0 #reseting the counter variables
            linecount += 1
        else: # checks that there is a data entry in the location if so adds the value to the sum otherwise it continues to the next hours data
            valuelist = str(row).split(',') # splits the columns data entries into separate indexes in the list
            try :
                sum += float(valuelist[location]) #attempts to cast the string as a float and add it to the sum
                recordings += 1 
            except:
                continue
            linecount +=1
        
    return 'The daily average for '+ monitoring_station+ ' is: ' ,average_list # returns the list of daily averages
  





def daily_median(data,monitoring_station:str, pollutant:str):
    """
    This function takes in the requested data,monitoring station and pollution type and calculates the median for each day of the year and returns these values in a list
    
    variables
    ---------
    linecount  this is used to count the lines in the file so that each days recordings can be identified
    data  this is the list containing the data for the specified monitoring station
    location  this is used to find the position in the list of data where the pollution number is
    median_list this is the container for each of the daily medians
    daily_list  this is the container for each hour in a day so that the list can be sorted and the median value can be obtained
    recordings  this is the number of data recordings that have been iterated through
    pollutant  this is the type of pollutant data that is wanting to be collected
    monitoring_station  this is the area that the pollution data is to be collected from
    filereader  this is the container that points to the csv file
    ---------
    returns:
    median_list
    
    """

    linecount = 0 
    location = 0
    recordings =0
    median_list = []
    daily_list = []
    if pollutant == "no":  #these 3 if statements help to determine the location of the correct data column to be retrieved
        location = 2
    elif pollutant == "pm10":
        location = 3
    elif pollutant == "pm25":
        location = 4
    else:
        return("Pollutant not found")
        
    if(data == {} or data == []):
        raise Exception("data set was empty")
   
    for row in data: #iterates through each row in the list
        if linecount == 0:  #identfies the first row as the headings and moves on without performing any operations to data
            linecount +=1
            continue
        elif linecount %25 == 0: #identifies that a whole 24hours of recordings has been added to the daily list variable then calculates the median
            if recordings %2 == 0:#this if statement handles the case where the list length is even
                if len(daily_list) == 0: #this statement handles if there is no data for a whole day
                    median_list.append("No data")
                else:
                    daily_list.sort() #sorts the list into size order
                    midpoint = int(len(daily_list) /2) #obtains the midpoint using the length of the list
                    median = ((daily_list[midpoint]) + (daily_list[midpoint-1]))/2 #calculates the median between the two middle values
                    median_list.append(median)   
            else:#this statement handles if the list has an odd length due to missing data
                daily_list.sort()
                median_list.append(daily_list[len(daily_list)]/2) #appends the middle value to the list of daily medians         
            recordings = 0 #reseting the counter variables
            linecount += 1
            daily_list.clear()#clears the list as a new day is going to be measured
        else: # checks that there is a data entry in the location if so adds the value to the otherwise it continues to the next hours data
            valuelist = row.split(',') #splits the data from each column into an entry in the list
            try :
                daily_list.append(float(valuelist[location])) #attempts to cast the string as a float and add it to the daily list
                recordings += 1 
            except:
                continue
            linecount +=1
    return "The daily median for " +monitoring_station+ ":",median_list # returns the list of daily medians

def hourly_average(data,monitoring_station:str, pollutant:str):
    """
    This function takes in the parameters data, monitoring_station to identify the area in which to obtain the data and pollutant which identifies which set of data to retrive,
    this data is then split into hour blocks and over the whole year each hour has been averaged to produce an hourly average

    variables
    --------
    linecount  is used to identify the current line number in the file
    data  is the list of data specified with the monitioring station
    location  is used to identify which data column should be accessed
    sumlist  is the container for the sums for each hour. each index in the list represents an hour between 00:00 and 24:00
    hourcounter is the container for the number of data points for each hour so that a correct average can be taken even if there is redundant data
    currenthour represents the current hour that is being accessed when reading a row in the data file
    average_list  is used to store the hourly averages 
    pollutant  this is the type of pollutant data that is wanting to be collected
    monitoring_station  this is the area that the pollution data is to be collected from

    --------
    returns:
    average_list
    """
    linecount = 0 
    location = 0
    sumlist = [0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0]
    hourcounter = [0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0]
    currenthour = 0
    average_list = []
    if pollutant == "no":  #these 3 if statements help to determine the location of the correct data column to be retrieved
        location = 2
    elif pollutant == "pm10":
        location = 3
    elif pollutant == "pm25":
        location = 4
    else:
        return("Pollutant not found")
       
    if(data == {} or data == []):
        raise Exception("data set was empty")
    for row in data: #iterates through each row in the list
        if linecount == 0:  #identfies the first row as the headings and moves on without performing any operations to data
            linecount +=1
            continue
        else: # checks that there is a data entry in the location if so adds the value to the sum otherwise it continues to the next hours data
            valuelist = row.split(',') # splits the columns data entries into separate indexes in the list
                    
            try :
                sumlist[currenthour] += float(valuelist[location]) #attempts to cast the string as a float and add it to the sum of the values at the current hour
                hourcounter[currenthour] += 1.0 #increments the hour counter at the position that represents the current hour         
            except:
                pass
            linecount +=1
            if(currenthour ==23): #identifies that it has reached the beginning of a new day and forces the currenthour to be reset to zero
                currenthour =0
                continue
            currenthour+=1
                    
        
        
    for i in range(0,24): #iterates through the sumlist and hourcounter list to calculate the average for each hour, the result is then appended to the average_list variable
        if(hourcounter[i] != 0):
            average_list.append(sumlist[i]/hourcounter[i])
        else:
            average_list.append(0.0)
    return "The hourly average for " +monitoring_station + ":",average_list # returns the list of hourly averages
   

def monthly_average(data,monitoring_station:str, pollutant:str):
    """
    This function iterates through each data record and identifies which month it is in. The data value at the location specified by the monitoring_station and pollutant is then added to the monthly sum.
    This monthly sum is divided by the total data entries for the month to produce an average for the month.

    variables
    ---------
    linecount  is used to identify the current line number in the file
    data  is the list of values associated with the monitoring station
    location  is used to identify which data column should be accessed
    sumlist  is the container for the sums for each month. Each index in the list represents a month of the year
    monthcounter is the container for the number of data points for each month so that a correct average can be taken even if there is redundant data
    currentmonth represents the current month that is being accessed when reading a row in the data file
    average_list  is used to store the monthly averages 
    pollutant  this is the type of pollutant data that is wanting to be collected
    monitoring_station  this is the area that the pollution data is to be collected from
    ---------
    returns:
    average_list

    """
    
    linecount = 0 
    location = 0
    sumlist = [0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0]
    monthcounter = [0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0]
    currentmonth = 0
    average_list = []
    if pollutant == "no":  #these 3 if statements help to determine the location of the correct data column to be retrieved
        location = 2
    elif pollutant == "pm10":
        location = 3
    elif pollutant == "pm25":
        location = 4
    else:
        return("Pollutant not found")
        
   
    if(data == {} or data == []):
        raise Exception("data set was empty")
    for row in data: #iterates through each row in the list
        if linecount == 0:  #identfies the first row as the headings and moves on without performing any operations to data
            linecount +=1
            continue
        else: # checks that there is a data entry in the location if so adds the value to the sum otherwise it continues to the next hours data
            valuelist = row.split(',') # splits the columns data entries into separate indexes in the list
            currentdate= row[0:10] #identifies the date of the current record
            datetolist = currentdate.split('-') #splits the date into year month and day into a list
            currentmonth = int(datetolist[1]) #identifies the month and casts it as a string
                            
            try :
                sumlist[currentmonth-1] += float(valuelist[location]) #attempts to cast the string as a float and add it to the sum of the values at the current month
                monthcounter[currentmonth-1] += 1.0 #increments the monthcounter at the position that represents the current month
                                
            except:
                continue
            linecount +=1
            currentmonth+=1
   
    for i in range(0,12): #iterates through the sumlist and hourcounter list to calculate the average for each month, the result is then appended to the average_list variable
        if(monthcounter[i] != 0): #handles the possibility of no data recorded for the whole month
            average_list.append(sumlist[i]/monthcounter[i])
        else:
            average_list.append("No data")
    return "The monthly average for " +monitoring_station + ":",average_list # returns the list of monthly averages
   


def peak_hour_date(data,date:str, monitoring_station:str,pollutant:str):
    """
    This function takes in the date that is wanting to be checked, the monitoring station that is being checked and the pollutant type to be checked and the data from the monitoring station.
    The function uses a temporary variable to check through each hour and compare the two pollutant amounts, it then updates the peakhour variable with the current highest emission hour.

    variables
    ---------
    linecount  is used to identify the current line number in the file
    data  is the list of values of data from the monitoring station
    location  is used to identify which data column should be accessed
    peakhour  is used to identify which is the current highest emission hour for that date
    temp  is used to store the current highest emission amount so that each hour can be checked against it to determine the peak hour
    pollutant  this is the type of pollutant data that is wanting to be collected
    monitoring_station  this is the area that the pollution data is to be collected from
    ---------
    returns:
    peakhour
    temp
    """
    linecount = 0 
    location = 0
    peakhour= 0
    temp = 0.0
    if pollutant == "no":  #these 3 if statements help to determine the location of the correct data column to be retrieved
        location = 2
    elif pollutant == "pm10":
        location = 3
    elif pollutant == "pm25":
        location = 4
    else:
        return("Pollutant not found")
       
    if(data == {} or data == []):
        raise Exception("data set was empty")
    for row in data: #iterates through each row in the list
        if linecount == 0:  #identfies the first row as the headings and moves on without performing any operations to data
            linecount +=1
            continue
        elif row[0:10] == date: #takes each row and slices the string to extract the date on each record, this is then compared against the date passed into the function
            valuelist = row.split(',') # splits the columns data entries into separate indexes in the list       
            try :
                if(float(valuelist[location])>temp): #takes the pollutant value and compares it to the temporary variable which is used to store the current highest pollutant value
                    temp = float(valuelist[location]) #reassigns the temp value if the value read is larger
                    peakhour = valuelist[1] #updates the peak hour             
            except:
                linecount += 1
                continue
                
        else:
            linecount +=1
            continue   
    return  "The peak hour and value for " +monitoring_station + ":",peakhour,temp
    



def count_missing_data(data,monitoring_station:str,pollutant:str):
    """
    This function takes in the data, monitoring station and pollutant parameters and iterates through all of the data for that pollutant type,
    It then increments the counter whenever a No data entry is encountered and then returns the total number of no data entries for the pollutant type at the monitoring station location provided

    variables
    ---------
    linecount  is used to identify the current line number in the file
    data  is the list of data values for the monitoring station
    location  is used to identify which data column should be accessed
    missingdatacounter  is used to count the number of no data entries for a given pollutant
    pollutant  this is the type of pollutant data that is wanting to be collected
    monitoring_station  this is the area that the pollution data is to be collected from
    ---------

    returns:
    missingdatacounter

    """
    linecount = 0 
    location = 0
    missingdatacounter = 0
    if pollutant == "no":  #these 3 if statements help to determine the location of the correct data column to be retrieved
        location = 2
    elif pollutant == "pm10":
        location = 3
    elif pollutant == "pm25":
        location = 4  
    else:
        return("Pollutant not found")
        
    if(data == {} or data == []):
        raise Exception("data set was empty")
    for row in data: #iterates through each row in the list
        if linecount == 0:  #identfies the first row as the headings and moves on without performing any operations to data
            linecount +=1
            continue
        else:
            valuelist = row.split(',') # splits the columns data entries into separate indexes in the list
            try :
                if(str(valuelist[location]) == "No data"): #casts the pollutant value to a string and compares it to the "No" string as this is how a no data entry is stored in the array
                    missingdatacounter += 1 #increments the counter if there is a No data entry
            except:
                pass
            linecount += 1              
    return "the missing data for " + monitoring_station +": ",missingdatacounter
   



def fill_missing_data(data, new_value,  monitoring_station:str,pollutant:str):
    """
    This function returns all data values for a given station and pollutant and replaces all missing data with the value associated with the new_value parameter.

    variables
    ---------
    output  stores the list of each hours data so that it can be output
    data  the list of data values for the monitoring station
    linecount  is used to identify the current line number in the file
    location  is used to identify which data column should be accessed
    new_value  is the value to replace the missing data
    pollutant  this is the type of pollutant data that is wanting to be collected
    monitoring_station  this is the area that the pollution data is to be collected from
    ---------
    returns:
    ouput

    """
    output = []
    linecount = 0 
    location = 0
    if pollutant == "no":  #these 3 if statements help to determine the location of the correct data column to be retrieved
        location = 2
    elif pollutant == "pm10":
        location = 3
    elif pollutant == "pm25":
        location = 4
    else:
        return("Pollutant not found")
        
    if(data == {} or data == []):
        raise Exception("data set was empty")
    for row in data: #iterates through each row in the list
        if linecount == 0:  #identfies the first row as the headings and moves on without performing any operations to data
            linecount +=1
            continue
        else: 
            valuelist = row.split(',') #splits the current row of the csv into a list
            if valuelist[location] == "No data": #identifies if the current data entry is missing
                output.append(new_value) #appends the new value to the output instead of the no data value
            else:
                output.append(valuelist[location]) #otherwise outputs the data as normal
    return "The completed data for " + monitoring_station + ": ",output # returns the list of values for the given pollutant and monitoring station
    
