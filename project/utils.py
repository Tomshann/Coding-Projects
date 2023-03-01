def sumvalues(values = []):
    """
    This function takes the parameter values which represents a list or array, 
    each value in the array is iterated over and added to the sum.
    If the iteration encounters a non numerical value it will throw an exception.

    variables
    ---------
    values  this is the array/list whose elements are being summed
    sum  this is the container for the sum of each element
    ---------
    returns:
    sum
    """    
    sum = 0.0
    for each in values: #iterates over the array/list
        try: 
            sum += each #attempts to add the value to the sum
        
        except:
            raise Exception("Non-numerical values present in the array") #raises an exception if the value in the array/list is not numerical
    return sum
            




def maxvalue(values = []):
    """
    This function takes the parameter values which represents a list or array, 
    the first value in the array is assigned as the current largest value,
    each value in the array is iterated over and compared to the current largest value in the array/list.
    If the value is larger then it will replace the value in the Largest_value variable.
    If the iteration encounters a non numerical value it will throw an exception.

    variables
    ---------
    values  this is the array/list whose elements are being compared
    Largest_value this is the container for the current largest value in the list
    ---------
    returns:
    Largest_value
    """    
    Largest_value = values[0] #assigns the first value of the array to be the current largest
    for each in values: #iterates throuugh each value in the array
        try:
            if(each > Largest_value): #compares the current element in the array to the largest value
                Largest_value = each #assigns the current index of list/array to the largest value if it is greater than the current largest value       
            else:
                continue#if the current element is smaller it continues with the next iteration
        except:
            raise Exception("Non-numerical values present in the array")# throws an exception if the current index is non-numerical
    return Largest_value



def minvalue(values = []):
    """
    This function takes the parameter values which represents a list or array, 
    the first value in the array is assigned as the current smallest value,
    each value in the array is iterated over and compared to the current smallest value in the array/list.
    if the value is smaller it will replace the value in the minimum_value variable.
    If the iteration encounters a non numerical value it will throw an exception.

    variables
    ---------
    values  this is the array/list whose elements are being compared
    minimum_value this is the container for the current smallest value in the list
    ---------
    returns:
    minimum_value
    """    
    minimum_value = values[0] #assigns the first index to the current smallest value
    for each in values: #iterates through each index in the array/list
        try:
            if(each < minimum_value): #compares the current index to the current smallest value
                minimum_value = each #replaces if the current index is smaller
            else:
                continue #if larger continue onto next iteration
        except:
            raise Exception("Non-numerical values present in the array")#raises an exception if there is a non-numerical value in the array/list
    return minimum_value


def meannvalue(values = [0]):
    """
    This function takes the parameter values which represents a list or array, 
    each value in the array is iterated over and added to the sum and then the total is averaged.
    If the iteration encounters a non numerical value it will throw an exception.

    variables
    ---------
    values  this is the array/list whose elements are being summed and averaged
    sum  this is the container for the sum of each element
    mean this is the result of the mean calculation of the data in the array/list
    ---------
    returns:
    mean
    """  
    sum = 0
    for each in values: #iterates through each value in the list
        try:
            sum += each  #adds the current index to the sum
        except:
            raise Exception("Non-numerical values present in the array")#raises an exception if there is a non-numerical value in the list/array
    if values == []:#checks for zero division
        raise Exception
    else:
        mean = round(sum/len(values),8)#calculates the mean using the sum and the length of the array/list and rounds to 8 d.p
        return mean

    


def countvalue(values = [], x = ''):
    """
    This function takes the parameters: values which represents a list or array and x which represents the target value to be searched for within the list/array, 
    each value in the array is iterated over and checked against x,
    if the value matches x the counter is increased.

    variables
    ---------
    values  this is the array/list whose elements are being checked to find the occurences of x
    x  this is the data item that is being searched for in the array
    valuecounter  this is the counter that identifies the number of occurences of x in the array/list
    ---------
    returns:
    valuecounter
    """    
    valuecounter = 0
    for each in values:
        if each == x:
            valuecounter += 1
        else:
            continue
    
    return valuecounter

