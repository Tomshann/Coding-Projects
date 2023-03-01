
def main_menu():
    """This method displays an interface and requests the user to choose one of the displayed options,
       if the choice is not one of the options the interface will request another input.
       When a correct choice is made it will display the menu for the choice they have 
       
       variables
       ---------
       validinput  this is the boolean variable that is used to determine if the user has entered a valid characeter
       choice  this is the users input character that is then checked to determine which menu to display
       ---------

    """
    validinput = False 
    while validinput == False: #loops until a valid character is input
        choice = input("Please choose one of the following options:\nR - Access the PR module\nI - Access the MI module\nM - Access the RM module\nA - Print the about text\nQ - Quit the application")#gets the users input choice
        if choice.capitalize() == 'R': #a series of if statements below to check to see if the input character is valid and then performing the function assigned to that input
            validinput = True
            reporting_menu()
        elif choice.capitalize() == 'I':
            validinput = True
            intelligence_menu()
        elif choice.capitalize() == 'M':
            validinput = True
            monitoring_menu()
        elif choice.capitalize() == 'A':
            validinput = True
            about()
        elif choice.capitalize() == 'Q':
            validinput = True
            quit()
        else:
            print("input character does not match any given option please try again")

def reporting_menu():
    import reporting
    import datetime
    """
    This method displays an interface and requests the user to choose one of the displayed options,
    if the choice is not one of the options the interface will request another input.
    When a correct choice is made it will request the input parameters then return the result to them through the interface and then return them to the main menu.

    variables
    ---------
    validinput  this is the boolean variable that is used to determine if the user has entered a valid characeter
    choice  this is the users input character that is then checked to determine which menu to display
    monitoringstation  this is the users desired monitoring station for the data to be retrieved from
    pollutant  this is the desired pollutant of which the data should be reported
    data1  this is the dictionary that contains all the data from the csv files
    ---------

    """

    validinput = False 
    while validinput == False: #loops until a valid character is input
        choice = input("Please choose one of the following options:\nDA - Access the Daily average module\nDM - Access the daily median module\nHA - Access the hourly average module\nMA - Acess the monthly average module\nPH - Access the peak hour module\nCM - Access the count missing data module\nFM - Access the fill missing data module\nR - Return to menu")#gets the users input choice
        if choice.upper() == 'DA': #a series of if statements below to check to see if the input character is valid and then performing the function assigned to that input, each statement requests input from the user to get the monitoring station and pollutant and then prints the result of the data operation performed
            validinput = True
            monitoringstation = input("please enter the desired monitoring station.").capitalize()
            pollutant = input("please enter the pollutant type to be reported").lower()
            if(monitoringstation == "Marylebone road"):
                data = data1["Marylebone Road"]
            elif monitoringstation == "Harlington":
                data = data1["Harlington"]
            elif monitoringstation == "N kensington":
                data = data1["N Kensington"]
            else:
                print("invalid monitoring station")
                main_menu()
            
            print(reporting.daily_average(data,monitoringstation,pollutant))
            
            main_menu()
        elif choice.upper() == 'DM':
            validinput = True
            monitoringstation = input("please enter the desired monitoring station.").capitalize()
            pollutant = input("please enter the pollutant type to be reported").lower()
            if(monitoringstation == "Marylebone road"):
                data = data1["Marylebone Road"]
            elif monitoringstation == "Harlington":
                data = data1["Harlington"]
            elif monitoringstation == "N kensington":
                data = data1["N Kensington"]
            else:
                print("invalid monitoring station")
                main_menu()
            
            print(reporting.daily_median(data,monitoringstation,pollutant))
            
            
            main_menu()
        elif choice.upper() == 'HA':
            validinput = True
            monitoringstation = input("please enter the desired monitoring station.").capitalize()
            pollutant = input("please enter the pollutant type to be reported").lower()
            if(monitoringstation == "Marylebone road"):
                data = data1["Marylebone Road"]
            elif monitoringstation == "Harlington":
                data = data1["Harlington"]
            elif monitoringstation == "N kensington":
                data = data1["N Kensington"]
            else:
                print("invalid monitoring station")
                main_menu()
            
            print(reporting.hourly_average(data,monitoringstation,pollutant))
            
            main_menu()
        elif choice.upper() == 'MA':
            validinput = True
            monitoringstation = input("please enter the desired monitoring station.").capitalize()
            pollutant = input("please enter the pollutant type to be reported").lower()
            if(monitoringstation == "Marylebone road"):
                data = data1["Marylebone Road"]
            elif monitoringstation == "Harlington":
                data = data1["Harlington"]
            elif monitoringstation == "N kensington":
                data = data1["N Kensington"]
            else:
                print("invalid monitoring station")
                main_menu()
            
            print(reporting.monthly_average(data,monitoringstation,pollutant))
            
            main_menu()
        elif choice.upper() == 'PH':
            validinput = True
            monitoringstation = input("please enter the desired monitoring station.").capitalize()
            pollutant = input("please enter the pollutant type to be reported").lower()
            date = input("Please input the date that the peak hour should be obtained from in the format: yyyy-mm-dd")
            x = False
            while x == False: #uses the datetime module in a try except statement to attempt to convert the input date into the format of yyyy-mm-dd if it fails it will ask for the user to reinput the date, if the year of the date is incorrect it will also ask the user to reinput the date
                try:
                    datetest = datetime.datetime.strptime(date, '%Y-%m-%d')
                    if(datetest.year == 2021):
                        x = True
                    else:
                        date = input("Incorrect year,Please input the date with a valid year in the format: yyyy-mm-dd")
                except:
                    date = input("Incorrect date,Please input the date that the peak hour should be obtained from in the format: yyyy-mm-dd")
            if(monitoringstation == "Marylebone road"):
                data = data1["Marylebone Road"]
            elif monitoringstation == "Harlington":
                data = data1["Harlington"]
            elif monitoringstation == "N kensington":
                data = data1["N Kensington"]
            else:
                print("invalid monitoring station")
                main_menu()
            
            print(reporting.peak_hour_date(data,str(date),monitoringstation,pollutant))
            
            main_menu()
        elif choice.upper() == 'CM':
            validinput = True
            monitoringstation = input("please enter the desired monitoring station.").capitalize()
            pollutant = input("please enter the pollutant type to be reported").lower()
            if(monitoringstation == "Marylebone road"):
                data = data1["Marylebone Road"]
            elif monitoringstation == "Harlington":
                data = data1["Harlington"]
            elif monitoringstation == "N kensington":
                data = data1["N Kensington"]
            else:
                print("invalid monitoring station")
                main_menu()
            
            print(reporting.count_missing_data(data,monitoringstation,pollutant))
            
            main_menu()
        elif choice.upper() == 'FM':
            validinput = True
            monitoringstation = input("please enter the desired monitoring station.").capitalize()
            pollutant = input("please enter the pollutant type to be reported").lower()
            newdata = input("Enter the new data value to replace the missing data")
            if(monitoringstation == "Marylebone road"):
                data = data1["Marylebone Road"]
            elif monitoringstation == "Harlington":
                data = data1["Harlington"]
            elif monitoringstation == "N kensington":
                data = data1["N Kensington"]
            else:
                print("invalid monitoring station")
                main_menu()
            
            print(reporting.fill_missing_data(data,newdata,monitoringstation,pollutant))
            
            main_menu()
        elif choice.capitalize() == 'R':
            main_menu()
        else:
            print("input character does not match any given option please try again")

    
    
def monitoring_menu():
    """Your documentation goes here"""
    import monitoring
    validinput = False 
    while validinput == False: #loops until a valid character is input and once a valid input is made it performs the function. Each module takes in the image filename and pixel colour to be identifed
        choice = input("Please choose an option:\nSI - Species information(returns details about each monitored species)\nPP - Peak Pollution(returns the highest hour of pollution for each species)\nLU - Live Update(displays a live statistic for each species)\nMM - monthy monitoring(displays a graph of the daily average for each specioes for a month period)\nR - return to menu")
        if choice.upper() == 'SI':
            validinput = True
            valid = False
            while valid == False:
                filtertype = input("Please select a filter to search for a species:\n1 - Species Code\n2 - Species Name\n3 - Description\n4 - Health effect")
                if filtertype == '1':
                    valid =True
                    filtertype = "SpeciesCode"
                elif filtertype == '2':
                    valid = True  
                    filtertype = "SpeciesName"
                elif filtertype == '3':
                    valid = True  
                    filtertype = "Description"  
                elif filtertype == '4':
                    valid = True    
                    filtertype = "HealthEffect"
                else:
                    print("invalid input try again")
            data = input("Please enter the data to filter for(THIS IS CASE SENSITIVE): ")
            inp = False
            while inp == False:
                items = input("Please select items to be returned in the form: 1,2,3,4:\n1 - Species Code\n2 - Species Name\n3 - Description\n4 - Health effect")
                numlist = items.split(',')
                returnitems = []
                x = False
                if numlist.__contains__('1'):
                    x = True
                    returnitems.append("SpeciesCode")
                if numlist.__contains__('2'):
                    x =True  
                    returnitems.append("SpeciesName")
                if numlist.__contains__('3'):
                    x =True  
                    returnitems.append("Description")  
                if numlist.__contains__('4'):
                    x =True    
                    returnitems.append("HealthEffect")
                if x == False:
                    print("invalid input try again")
                if x == True:
                    inp = True
    
            try:
             monitoring.species_information(data,filtertype,returnitems)
             main_menu()
            except:
                print("one or more parameters were incorrect")
                main_menu()

        elif choice.upper() == 'PP':
            validinput = True
            sitecode = input("Please enter the sitecode of the area you wish to find the peak pollution hour for each species")
            day = input("Please enter the day of the date eg. 1 or 27")
            month = input("Please enter the month of the date eg. 1 or 12")
            year = input("Please enter the year of the date eg. 2022")
            try:
                monitoring.peak_pollution(sitecode.upper(),int(day),int(month),int(year))
                main_menu()
            except:
                print("one or more parameters were incorrect")
                main_menu()
        elif choice.upper() == 'LU':
            validinput = True
            sitecode = input("please enter the sitecode of the area you wish to find the peak pollution hours")
            try:
                monitoring.live_update(sitecode.upper())
                main_menu()
            except:
                print("sitecode not found")
                main_menu()
        elif choice.upper() == 'MM':
            validinput = True
            sitecode = input("Please enter the sitecode of the area you wish to find the peak pollution hour fo each species")
            month = input("Please enter the month of the date eg. 1 or 12")
            year = input("Please enter the year of the date eg. 2022")
            try:
                monitoring.monthly_monitoring_index(sitecode.upper(),int(year),int(month))
                main_menu()
            except:
                print("one or more parameters were incorrect")
                main_menu()
        elif choice.upper() == 'R':
            validinput = True
            main_menu()
        else:
            print("invalid input please try again")

def intelligence_menu():
    """
    This method provides an interface for the user to use the intelligence module. It requests a character input to select each function.
    if the choice is not one of the options the interface will request another input.
    otherwise it will execute the function
    """
    import intelligence
    validinput = False 
    while validinput == False: #loops until a valid character is input and once a valid input is made it performs the function. Each module takes in the image filename and pixel colour to be identifed
        choice = input("please choose an option:\nFR - find red pixels\nFC - find cyan pixels\nDC - detect connected components\nDCS - detect connected components sorted\nR - return to menu")
        if choice.upper() == 'FR':
            validinput = True
            filename = input("please enter the filename of the image: ")
            upper = input("please enter the upper colour threshold of the image: ")
            lower = input("please enter the lower threshold of the image:")
            try:
                intelligence.find_red_pixels(filename,int(upper),int(lower))
                main_menu()
            except:
                print("File not found")
                main_menu()
        elif choice.upper() == 'FC':
            validinput = True
            filename = input("please enter the filename of the image: ")
            upper = input("please enter the upper colour threshold of the image: ")
            lower = input("please enter the lower threshold of the image:")
            try:
                intelligence.find_cyan_pixels(filename,int(upper),int(lower))
                main_menu()
            except:
                print("File not found")
                main_menu()
        elif choice.upper() == 'DC':
            validinput = True
            filename = input("please enter the filename of the image: ")
            upper = input("please enter the upper colour threshold of the image: ")
            lower = input("please enter the lower threshold of the image:")
            vinp = False
            while vinp == False:
                colour = input("please enter the colour of which to detect the connected components either Red or Cyan") #checks to ensure a correct colour is input
                if colour.upper() == 'RED':
                    vinp = True
                    intelligence.detect_connected_components(intelligence.find_red_pixels(filename,int(upper),int(lower)))
                    main_menu()
                elif colour.upper() == 'CYAN':
                    vinp = True
                    intelligence.detect_connected_components(intelligence.find_cyan_pixels(filename,int(upper),int(lower)))
                    main_menu()
                else:
                    print("invalid input try again.")
        elif choice.upper() == 'DCS':
            validinput = True
            filename = input("please enter the filename of the image: ")
            upper = input("please enter the upper colour threshold of the image: ")
            lower = input("please enter the lower threshold of the image:")
            vinp = False
            while vinp == False:
                colour = input("please enter the colour of which to detect the connected components either Red or Cyan") #checks to see if an input colour is valid
                if colour.upper() == 'RED':
                    vinp = True
                    intelligence.detect_connected_components_sorted(intelligence.detect_connected_components(intelligence.find_red_pixels(filename,int(upper),int(lower))))
                    main_menu()
                elif colour.upper() == 'CYAN':
                    vinp = True
                    intelligence.detect_connected_components_sorted(intelligence.detect_connected_components(intelligence.find_cyan_pixels(filename,int(upper),int(lower))))
                    main_menu()
                else:
                    print("invalid input try again.")
        elif choice.capitalize() == 'R':
            validinput = True
            main_menu()
        else:
            print("invalid input please try again")


def about(): 
    """
    This method prints the module identifier and my candidate number
    """
    print("ECM1400")
    print("255917")
    main_menu()

def quit():
    """
    This method ends the execution of the program
    """
    exit()
    




if __name__ == "__main__":
    import csv
    data1 = {"Marylebone Road" :[], "Harlington" : [] , "N Kensington" : []} #initilalises the keys into the dictionary with empty lists
    #adding all the csv values as lists into the dictionaries
    with open("./data/Pollution-London Marylebone Road.csv",newline='') as csvfile:
                    filereader = csv.reader(csvfile, delimiter ='\n') # creates a variable that points to the csv file
                    for row in filereader:
                        data1["Marylebone Road"] += row
                       
    with open("./data/Pollution-London Harlington.csv",newline='') as csvfile:
                    filereader = csv.reader(csvfile, delimiter ='\n') # creates a variable that points to the csv file
                    for row in filereader:
                        data1["Harlington"] += row
    with open("./data/Pollution-London N Kensington.csv",newline='') as csvfile:
                    filereader = csv.reader(csvfile, delimiter ='\n') # creates a variable that points to the csv file
                    for row in filereader:
                        data1["N Kensington"] += row

    csvfile.close()
    main_menu()
