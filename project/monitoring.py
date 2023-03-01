

def get_live_data_from_api(site_code='MY1',species_code='NO',start_date=None,end_date=None):
    """
    Return data from the LondonAir API using its AirQuality API. 
    
    *** This function is provided as an example of how to retrieve data from the API. ***
    It requires the `requests` library which needs to be installed. 
    In order to use this function you first have to install the `requests` library.
    This code is provided as-is. 
    """
    import requests
    import datetime
    start_date = datetime.date.today() if start_date is None else start_date
    end_date = start_date + datetime.timedelta(days=1) if end_date is None else end_date
    
    
    endpoint = "https://api.erg.ic.ac.uk/AirQuality/Data/SiteSpecies/SiteCode={site_code}/SpeciesCode={species_code}/StartDate={start_date}/EndDate={end_date}/Json"
   
    url = endpoint.format(
        site_code = site_code,
        species_code = species_code,
        start_date = start_date,
        end_date = end_date
    )
    
    res = requests.get(url)
    return res.json()


def species_information(data:str,filter:str,returnitems = ['SpeciesCode','SpeciesName','Description','HealthEffect']): #use this function as a pollutant information provider
    """Returns information about a given species. The user can filter by each characteristic of the species e.g.(name,code,description,health effect)
       The function will return the pieces of information specified by the contents of the returnitems parameter

       Parameters
       ----------
       data  this is the item that the user wants to filter by
       filter  this is the location in the dictionary that would contain the data parameter if it exists
       returnitems  this is the list of characteristics that the user wants to be retruned
    """
    import requests
    
    
    endpoint = "http://api.erg.ic.ac.uk/AirQuality/Information/Species/Json" #the api request for the information data
    
    res = requests.get(endpoint)
    result = res.json()
    for each in result['AirQualitySpecies']['Species']: #iterates through each species
        if data == each['@'+filter]: #matches the data item to the value specifeied in the dictionary by the filter key
            for x in returnitems: #iterates through the list of returns items to see if the characteristic is meant to be returned. if it is to be returned then retuns it.
                if x == 'SpeciesCode':
                     print('Species code: '+str(each['@SpeciesCode']))
                elif x == 'SpeciesName':
                    print('Species Name: '+str(each['@SpeciesName']))
                elif x == 'Description':
                    print('Description: '+ str(each['@Description']))
                elif x == 'HealthEffect':
                    print('Health effect: '+str(each['@HealthEffect']))
    print('\n') 
  
    
def peak_pollution(sitecode,day,month,year): #create a new function here
    """
    This function takes in the sitecode parameter and day,month and year to return the hour with the highest index for each species

    parameters
    ----------
    sitecode  this is the code for the location that the data should be taken from
    day,month,year  these are used to form the date for the API request
    """
    import requests
    import datetime

       
    startdate =  datetime.datetime(year,month,day).date() #creates the dates
    enddate = datetime.datetime(year,month,day+1).date()
    
    endpoint = "https://api.erg.ic.ac.uk/AirQuality/Data/Site/SiteCode={SITECODE}/StartDate={STARTDATE}/EndDate={ENDDATE}/Json"
               
    url = endpoint.format(
        SITECODE = sitecode,
        STARTDATE =startdate,
        ENDDATE = enddate
    )
    try:
        res = requests.get(url)
    except:
        raise Exception
   
    result = res.json()
    peakspecies = {}
    for each in result['AirQualityData']['Data']:#iterates through the data
        speciescode =each['@SpeciesCode'] #identifies the speciescode
        if speciescode in peakspecies or speciescode =='FINE':#checks to see if the speciescode is present in the dictionary or redundant
            pass # if already in the dictionary or redundant continue
        else:
            peakspecies[speciescode] = ['',0] #adds the key to the dictionary
        if each['@Value']!= '': #checks to see if there is data
            if float(each['@Value'])>peakspecies[each['@SpeciesCode']][1]:#checks to see if the new value is greater than the current highest value
                peakspecies[each['@SpeciesCode']][1] = float(each['@Value'])#replaces the value in the dict 
                peakspecies[each['@SpeciesCode']][0] = each['@MeasurementDateGMT']#replaces the peak time in the dictionary
    
    for each in peakspecies:#iterates through the dictionary returning the pollutant the time(sliced from the full date/time) and monitoring index
        print('The Peak hour on ' + str(startdate) + " for "+ each +" was: " + peakspecies[each][0][12:19]+ " with an index of: "+str(peakspecies[each][1]))



def live_update(sitecode):
    """This function provides lives statistics for a particular sitecode. The data is refreshed every 10 minutes to check for updates as the data os only updated approximately evey hour
    
    Parameters
    ----------
    sitecode  this is the sitecode of the location that the user wants to obtain the live data from
    ----------
    """
    import requests
    import time
    import os
    try: #this try except statement handles the exception thrown when the user presses Ctrl-C to exit the live feed
        while True:
            endpoint = "http://api.erg.ic.ac.uk/AirQuality/Hourly/MonitoringIndex/SiteCode={SITECODE}/Json" #requests the data from the api
        
            url = endpoint.format( #formats the URL
                SITECODE = sitecode
            )
            
            res = requests.get(url)
            result = res.json()
            clear = lambda: os.system('cls') #creates a method that clears the terminal so that data is just refreshed rather than printed multiple times when it refreshes
            clear() #clears the terminal
            
            print("(The results will refresh every 10 minutes to see if there is new data)"+'\n'+"The current hour statistics for " + sitecode + ": ") 
            for each in result['HourlyAirQualityIndex']['LocalAuthority']['Site']['species']:
                print(each['@SpeciesName']+': Air Quality Index: ' + each['@AirQualityIndex']+' ,Air Quality Band: ' +each['@AirQualityBand'])#returns the data line by line for each species present
            print("Press Ctrl-C to exit this module")   
            time.sleep(600) #pauses execution of the while loop for 10 minutes
    except KeyboardInterrupt:
        pass #when CTRL-C is pressed exits the function


def monthly_monitoring_index(site_code,year,month):
    """
    This function takes the site code year and month and plots a graph of the average monitoring index for each pollution type for each day of the month

    parameters
    ----------
    site_code  this is the sitecode of the location that the data should be averaged from
    year  this is the year of the date that the data should be obtained
    month this is the moneth of the date that the data should be obtained
    """
    import requests
    import datetime
    import matplotlib.pyplot as plt
    thirty1days = [1,3,5,7,8,10,12] #these 3 lists represent the month of the year and how many days are in them
    thirtydays = [4,6,9,11]
    february = [2]
    daycount = 0
    if(thirty1days.__contains__(month)):#checks to see how many days are in the month present
        daycount = 31
    elif(thirtydays.__contains__(month)):
        daycount = 30
    elif(february.__contains__(month)):
        if int(str(year)[2:4])%4 == 0:#this checks to see if it is a leap year
            daycount = 29
        else:
            daycount = 28
    start_date = datetime.datetime(year,month,1) #identifies the start and end dates
    end_date = datetime.datetime(year,month,daycount)
    
    
    
    endpoint = "https://api.erg.ic.ac.uk/AirQuality/Data/Site/SiteCode={SITECODE}/StartDate={STARTDATE}/EndDate={ENDDATE}/Json"
   
    url = endpoint.format(
        SITECODE = site_code,
        STARTDATE = start_date.date(),
        ENDDATE = end_date.date()
    )
    
    try:
        res = requests.get(url)
    except:
        raise Exception
    result = res.json()
    total = 0 
    recordcounter = 0
    hourcounter = 1
    speciesaverages = {}
    currentday = 1
    for i in range(0,len(result['AirQualityData']['Data'])):#iterates over the data returned from the GET request
        speciescode =result['AirQualityData']['Data'][i]['@SpeciesCode'] #obtains the species code
        if speciescode in speciesaverages or speciescode == 'FINE':#checks to see if the species code is a key in the dictionary
            pass #if it is in the dictionary or redundant data then continues
        else:
            speciesaverages[speciescode] = [] #creates a dictionary reference for the data
            currentday = 0 #identifies that the data for the next pollutant has begun
        if result['AirQualityData']['Data'][i]['@Value'] == '': #checks to see if there is no data
            hourcounter+=1
            continue
        elif hourcounter %24 == 0:#checks to see if the hour counter has reached the end of the day
            average = total/recordcounter #calculates the average
            speciesaverages[speciescode].append((currentday,average))#stores the average in the dictionary 
            currentday +=1 #resetting variables
            recordcounter = 0
            hourcounter+=1
            total =0
        else:
            total += float(result['AirQualityData']['Data'][i]['@Value']) #adds the value to the total
            recordcounter +=1
            hourcounter+=1

   
    for each in speciesaverages: #iterates over the dictionary
        label = each #creates a label for the line from the speciescode
        xlist = [] 
        for x in speciesaverages[each]:#iterates over the values in the dictionary and appends them to the list
            xlist.append(x[0])
        ylist = []
        for y in speciesaverages[each]:#iterates over the values in the dictionary and appends them to the list
            ylist.append(y[1])
        plt.plot(xlist,ylist,label = label) #plots the x,y pair values 
    
    plt.xlabel('Day') #labels the axis
    plt.ylabel('Average Monitoring Index')
    plt.legend()
    plt.show()#shows the graph


    
            
        