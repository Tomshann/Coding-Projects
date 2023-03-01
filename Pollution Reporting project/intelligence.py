import numpy as np
from matplotlib import image,pyplot

def find_red_pixels(map_filename,upperthreshold = 100, lowerthreshold = 50):
    """
    This function takes an image file and iterates over each pixel in the image and converts any red pixels into white pixels and turns all other pixels black,
    this effectively creates a new jpg image that shows just the red pixels in the image
    variables
    ---------
    map_filename  this is the name of the image file for the red pixel to be obtained from
    upperthreshold  this i() the limit which shows that any value above it means that a color is prominent in the pixel
    lower threshold this is the limit to show that anything less that it mean that this color is not prominent in the pixel
    image  this is the ndarray that is produced from reading the image that is passed into this function
    outputimage  this is a copy of the  original image array that is modified to the black and white color scheme
    return image  this is a copy of the original image array that is modified to represent each pixel in binary 1 = white 0 = black
    ---------
    returns:
    returnimage
    """
    
    try:
        img = image.imread("./data/" + map_filename) #converts image file into an ndarray of pixels
        outputimage = image.imread("./data/" + map_filename) #creates a copy of the image array 
        returnimage = image.imread("./data/" + map_filename)
        img = img *255 #converts each rgb value from float to int 
    except:
        raise Exception
    
    
    for z in range(0,np.shape(img)[1]): #iterates row by row in the image and measures the colour of each pixel against the thresholds
        for i in range(0,np.shape(img)[0]): 
            if(round(img[i][z][0])>=int(upperthreshold) and round(img[i][z][1])<=int(lowerthreshold) and round(img[i][z][2])<=int(lowerthreshold)):
                outputimage[i][z] = [1,1,1,1] #if pixel is deemed to be red then set the output images value of the pixel to white
                returnimage[i][z] = 1 #sets the binary output pixel value to 1 to represent a white pixel
            else:
                outputimage[i][z] = [0,0,0,1]#if pixel is not red set its value to black
                returnimage[i][z] = 0 #sets the binary value of the pixel to 0 = black
    
    pyplot.imsave("map-red-pixels.jpg",outputimage)#saves the output image as a jpg 
    return returnimage[:,:,:1]#returns a sliced image with only one value per pixel


def find_cyan_pixels(map_filename,upperthreshold = 100, lowerthreshold = 50):
    """
    This function takes an image file and iterates over each pixel in the image and converts any cyan pixels into white pixels and turns all other pixels black,
    this effectively creates a new jpg image that shows just the cyan pixels in the image
    variables
    ---------
    map_filename  this is the name of the image file for the cyan pixels to be obtained from
    upperthreshold  this is the limit which shows that any value above it means that a color is prominent in the pixel
    lower threshold this is the limit to show that anything less that it mean that this color is not prominent in the pixel
    image  this is the ndarray that is produced from reading the image that is passed into this function
    outputimage  this is a copy of the  original image array that is modified to the black and white color scheme
    return image  this is a copy of the original image array that is modified to represent each pixel in binary 1 = white 0 = black
    ---------
    returns:
    returnimage"""
    try:
        img = image.imread("./data/" + map_filename) #converts image file into an ndarray of pixels
        outputimage = image.imread("./data/" + map_filename) #creates a copy of the image array
        returnimage = image.imread("./data/" + map_filename)
        img = img*255 # converts each rgb value to an integer
    except:
        raise Exception
    
    for z in range(0,np.shape(img)[1]): #iterates row by row in the image and measures the colour of each pixel against the thresholds
        for i in range(0,np.shape(img)[0]): 
            if(round(img[i][z][0])<=int(lowerthreshold) and round(img[i][z][1])>=int(upperthreshold) and round(img[i][z][2])>=int(upperthreshold)):
                outputimage[i][z] = [1,1,1,1] #if pixel is deemed to be cyan then set the output images value of the pixel to white
                returnimage[i][z] = 1 #sets the binary output pixel value to 1 to represent a white pixel
            else:
                outputimage[i][z] = [0,0,0,1]#if pixel is not cyan set its value to black
                returnimage[i][z] = 0 #sets the binary value of the pixel to 0 = black
    
    pyplot.imsave("map-cyan-pixels.jpg",(outputimage))#saves the output image as a jpg 
    return returnimage[:,:,:1] #returns the return image sliced so that each pixel is represented by 1 bit either a zero or a 1



def detect_connected_components(IMG):
    """
    This function takes in a binary image and iterates row by row through the im age to detect reigons of connected components

    variables
    ---------
    Mark  is the 2darray that stores which pixels in the image have been visited
    queue  is the ndarray that stores each pixel that is to be visited next
    marker  is the value that assigns each pixel in the image to a connected component, this is incremented once a new connected component is found
    ---------
    returns:
    Mark

    """
    
    
    Mark = np.zeros(np.shape(IMG),dtype= np.int16)#initialises an array of same size as the image filled with zeros to represent unvisited pixels
    queue = np.array([],dtype= np.int16) #initialises an empty array that is used to store the next pixels to be visitied
    marker = 0 #used to identify the current connnected component
    
    
    for y in range(0,np.shape(IMG)[0]): 
        for x in range(0,(np.shape(IMG)[1])): #iterates row by row in the IMG array
            if IMG[y][x][0] == 1 and Mark[y][x][0]==0: #cheks to see if the pxiel is a pavement pixel and as an improvement to the origninal psuedocode it also checks to see if the pixel has already been visited
                marker +=1 # increments the connected component marker
                Mark[y][x][0] = marker #marks the pixel as visited
                queue = np.append(queue,[y,x]) #adds the pixel to the queue
                queue.shape = (-1,2) #reshapes the queue ndarray
                while len(queue) >0: #iterates through each pixel in the connected component
                   currentpixel = queue[0] #marks the current pixel as the first item in the queue
                   if (currentpixel[1] !=np.shape(IMG)[1]-1 and currentpixel[1]!=0) and (currentpixel[0] !=np.shape(IMG)[0]-1 and currentpixel[0] != 0): #the following if statements are an imporvement to the original algorithm as they provide boundary checks on the image as some pixles will not have all 8 neighbours
                    eightneighbours = [[currentpixel[0]-1,currentpixel[1]],[currentpixel[0]+1,currentpixel[1]],[currentpixel[0],currentpixel[1]-1],[currentpixel[0],currentpixel[1]+1],[currentpixel[0]-1,currentpixel[1]-1],[currentpixel[0]+1,currentpixel[1]-1],[currentpixel[0]+1,currentpixel[1]+1],[currentpixel[0]-1,currentpixel[1]+1]]
                   elif currentpixel[1]==np.shape(IMG)[1]-1:
                    eightneighbours = [[currentpixel[0]-1,currentpixel[1]],[currentpixel[0]+1,currentpixel[1]],[currentpixel[0],currentpixel[1]-1],[currentpixel[0]-1,currentpixel[1]-1],[currentpixel[0]+1,currentpixel[1]-1]]
                   elif currentpixel[1]==0:
                    eightneighbours = [[currentpixel[0]-1,currentpixel[1]],[currentpixel[0]+1,currentpixel[1]],[currentpixel[0],currentpixel[1]+1],[currentpixel[0]+1,currentpixel[1]+1],[currentpixel[0]-1,currentpixel[1]+1]]
                   elif currentpixel[0] ==np.shape(IMG)[0]-1:
                    eightneighbours = [[currentpixel[0]-1,currentpixel[1]],[currentpixel[0],currentpixel[1]-1],[currentpixel[0],currentpixel[1]+1],[currentpixel[0]-1,currentpixel[1]-1],[currentpixel[0]-1,currentpixel[1]+1]]
                   elif currentpixel[0] == 0:
                    eightneighbours = [[currentpixel[0]+1,currentpixel[1]],[currentpixel[0],currentpixel[1]-1],[currentpixel[0],currentpixel[1]+1],[currentpixel[0]+1,currentpixel[1]-1],[currentpixel[0]+1,currentpixel[1]+1]]
                   
                   queue = np.delete(queue,0,axis=0) #dequeues the first node in the queue
                   queue.shape = (-1,2) #reshapes the queue
                   for each in eightneighbours:
                    if IMG[each[0]][each[1]] == 1 and Mark[each[0]][each[1]][0] == 0: #checks to see if each neighbour is a pavement pixel and that it has not been visited
                        Mark[each[0]][each[1]][0] = marker #marks the pixel as visited
                        queue = np.append(queue,each) #adds the pxiel to the queue
                        queue.shape=(-1,2) # reshapes the queue
               
                 
    connectedcomponents={} #creates an empty dictionary for the connected components to be read into
    for i in range(1,marker+1): #iterates up to the marker value and adds a dictionary key for each value with a value of zero
        connectedcomponents[str(i)] = 0
    for each in np.nditer(Mark): #iterates over the mark array and increments the value of the key in the dictionary
        if connectedcomponents.get(str(each)) != None:
            connectedcomponents[str(each)] +=1
        
    f = open("cc-output-2a.txt",'w') #opens the text file to write the components
    for each in connectedcomponents: #iterates over each component and writes it into the file
        f.write("connected component "+each+", number of pixels = "+str(connectedcomponents[each])+"\n")
    f.writelines("total number of connected components = " + str(marker)) #writes the total number of components
    return Mark


    


def detect_connected_components_sorted(mark):
    """
    This function takes in the array of marked connected components and writes a sorted list of the components into a text file
    """
    connectedcomponents={} # initialises an empty dictionary
    
    for each in np.nditer(mark): #iterates over the mark array if the value of the current pixel is not zero and it doesnt have a dictionary reference then create a new key otherwise increment the value of the key
        if(each == 0):
            continue
        else:
            if str(each) in connectedcomponents:
                if connectedcomponents.get(str(each)) != None:
                    connectedcomponents[str(each)] +=1
            else:
                connectedcomponents[str(each)] = 1

    sortedoutput = [] #creates an empty output to sort the dictionary values into
    
    for each in connectedcomponents: #iterates over the dictionary
        inserted = False  
        if(sortedoutput == []): #if the array is empty add the value to the array
            sortedoutput.append((each,connectedcomponents[each]))
        else:
            for i in range(0,len(sortedoutput)): #iterates over the sorted list
                if inserted == False: #if the object hasnt been placed into the list
                    if(connectedcomponents[each]>= sortedoutput[i][1]): #if the value is greater than the current index then insert the value in this position otherwise continue
                            sortedoutput.insert(i,(each,connectedcomponents[each]))
                            inserted = True
                    else:
                        continue
            if inserted == False: #if the value was not inserted then add to the end of the list as this is the new smallest value
                sortedoutput.append((each,connectedcomponents[each]))
    
    f = open("cc-output-2b.txt",'w') #opens a file to write the sorted list in
    for each in sortedoutput:
        f.write("connected component "+each[0]+", number of pixels = "+str(each[1])+"\n") #writes the sorted list into the file
    f.writelines("total number of connected components = " + str(len(connectedcomponents))) #writes the number of connected components

    img = np.zeros((np.shape(mark)[0],np.shape(mark)[1],3)) #creates an image of black pixels
    for y in range (0,np.shape(mark)[0]): 
        for x in range(0,(np.shape(mark)[1])):#iterates row by row through the image
            
            if(mark[y][x][0] == int(sortedoutput[0][0])) or mark[y][x][0] == int(sortedoutput[1][0]): #checks to see if the pixel value in the mark array mathces one of the two largest components
                img[y][x] = [1,1,1] #marks the pixel as white
            else:
                img[y][x] = [0,0,0] #marks the pixel as black
            
    
    pyplot.imsave("cc-top-2.jpg",img)#saves the output image as a jpg
    
