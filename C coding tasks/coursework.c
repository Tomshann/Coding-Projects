#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <unistd.h>
#include <errno.h>
#include "msString.h"
void printBytes (void *,int);
void reverseString (char *);
int main(int argc, char *argv[]){
	/*Create test data for the printBytes function*/
	unsigned char test[] = {10,20,30,145};
	unsigned char test2[] = {6,15,255,3,1,2,3,4,6,7};
	printBytes(test,4);
	printBytes(test2,10);
	/*testing the reverse string*/
	if (argc !=3){ /*checks the number of arguments passed to main is correct*/
		printf("Usage: %s fileIn fileOut\n",argv[0]);
		return 1;
	}
	
	char *fileIn = argv[1];
	char *fileOut = argv[2];
	FILE *inputFile = fopen(fileIn,"r");
	/*assigns the input files to variables then checks that they can be opened*/
	if(inputFile == NULL){
		printf("Unable to read input file:\n");
		fprintf(stderr, "error %d:",errno,strerror(errno));
		return 1;
		
	}
	FILE *outputFile = fopen(fileOut,"w");
	if(outputFile == NULL){
		printf("Unable to write to output file:\n");
		fprintf(stderr, "error %d:", errno,strerror(errno));
		fclose(inputFile);
		return 1;
		
	}
	char *line = NULL;
	size_t len =0;
	ssize_t read;
	if((read = getline(&line,&len,inputFile))!=-1){/*reads over the lines and strips off null characters*/
		if(line[read-1] == '\n')
			line[read -1] = '\0';
		reverseString(line);/*calls the reverse function to reverse the string*/
		fprintf(outputFile, "%s\n",line);/*writes the reversed string into the output file*/
	}
	printf("string reversed sucessfully\n");
	free(line); /*free the memory taken up by the line pointer and close the files*/
	fclose(inputFile);
	fclose(outputFile);

	/* testing msString*/
	msString ms = msSetString("Hello");
	msString ms2 = msSetString( "World !");
	msString mscopy = NULL;
	/*CHECK IF MEMORY WAS ALLOCATED SUCCESSFULLY*/
	if(ms == NULL || ms2 ==NULL){
		return 1;
	}
	printf("string |%s| is %ld characters long (%p).\n",msGetString(ms),msLength(ms),(void *)ms);
	/*allocate memory for mscopy and check it is allocated successfully*/
	mscopy = msSetString("");
 	if (mscopy == NULL) {
        	free(ms);/*deallocate memory to prevent leak*/
        	free(ms2);
        	free(mscopy);
		return 1;
        }
	msCopy(&mscopy, ms);/*acopy ms into mscopy*/
	/*CHECK IF MEMORY ALLOCATED SUCCESSFULLY*/
	if(mscopy == NULL){
		/*Deallocate memory to prevent memory leak*/
		free(ms);
		free(ms2);
		free(mscopy);
		return 1;
	}
	 printf("Copied string |%s| is %ld characters long (%p).\n",
           msGetString(mscopy), msLength(mscopy), (void *)mscopy);

   	 printf("Compare ms with mscopy: %d\n", msCompare(ms, mscopy));
   	 printf("Compare ms with ms2: %d\n", msCompare(ms, ms2));
   	 printf("Compare ms with Hello: %d\n", msCompareString(ms, "Hello"));
   	 printf("Compare ms with HelloX: %d\n", msCompareString(ms, "HelloX"));
   	 printf("Compare ms with Hella: %d\n", msCompareString(ms, "Hella"));

   	 msConcatenate(&mscopy, ms2);
   	 printf("Concatenated string |%s| is %ld characters long (%p).\n", msGetString(mscopy), msLength(mscopy), (void *)mscopy);

    	/*Deallocate memory to avoid memory leak*/
        free(ms);
        free(ms2);
        free(mscopy);					
	return 0;
}

void printBytes (void *ptr,int numBytes){
	unsigned char *byteptr = (unsigned char *)ptr; /*using a char pointer as it is guaranteed to take up one byte at a time*/
	printf("Starting at memory address %p :\n",ptr);/*outputs the starting memory address*/
	int i =0;
	for(i;i<numBytes;i++){
		printf("%03d: %d\n",i+1,byteptr[i]); /*iterates over the number of specified bytes and backfills the output text with zeros such that it is in the correct format*/
	}
}

void reverseString (char *str){
	int length = strlen(str);
	char temp;
	int j=0;
	for (j; j<length/2; j++){ /*iterates up to the the middle of the string swapping the characters at opposite positions*/
		temp=str[j];
		str[j] = str[length -j-1];
		str[length -j-1]=temp;
	}
}

