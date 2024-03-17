#include "msString.h"

msString msSetString(char *str) {
    if (str == NULL) {
        msError("Error: Input string is NULL.");
        return NULL;
    }

    size_t len = strlen(str);
    /*allocate memory and check it has been allocated sucessfully*/
    msString new_msString = malloc((len) * sizeof(long int) + len * sizeof(char));/*ensure null terminator isnt stored*/
    if (new_msString == NULL) {
        msError("Error: Memory allocation failed for msString.");
        return NULL;
    }

    *((long int *)new_msString) = (long int)len;/*copy the length of the string into the memory address*/
    memcpy((char *)new_msString + sizeof(long int), str, len);/*copy the string into the memory directly after the interger*/

    return new_msString;
}

char *msGetString(msString ms) {
    if (ms == NULL) {
        msError("Error: msString is NULL.");
        return NULL;
    }

    long int len = *((long int *)ms);
    char *str = (char *)ms + sizeof(long int); 
    str[len] = '\0';/*adds the null character back to the string so that it can be read correctly*/

    return str;
}


void msCopy(msString *dest, msString src) {
    if (src == NULL) {
        msError("Error: Source msString is NULL.");
        return;
    }

    if (*dest != NULL) {/*frees memory if the destination pointer is null*/
        free(*dest);
    }

    size_t len = *((long int *)src);

    *dest = malloc((len + 1) * sizeof(long int) + len * sizeof(char));/*allocates memory and checks the allocation is successful*/ 
    if (*dest == NULL) {
        msError("Error: Memory allocation failed for destination msString.");
        return;
    }

    *((long int *)*dest) = (long int)len;
    memcpy((char *)*dest + sizeof(long int), (char *)src + sizeof(long int), len);
}

void msConcatenate(msString *dest, msString src) {
    if (src == NULL) {
        msError("Error: Source msString is NULL.");
        return;
    }

    size_t src_len = *((long int *)src);
    size_t dest_len = (*dest != NULL) ? *((long int *)*dest) : 0;

    *dest = realloc(*dest, (dest_len + src_len + 1) * sizeof(long int) + (dest_len + src_len) * sizeof(char));/*allocate memory and check it is sucessful*/
    if (*dest == NULL) {
        msError("Error: Memory reallocation failed for destination msString during concatenation.");
        return;
    }

    *((long int *)*dest) = (long int)(dest_len + src_len);

    memcpy((char *)*dest + sizeof(long int) + dest_len, (char *)src + sizeof(long int), src_len); /*copies the concatenated string into memory*/
}

long int msLength(msString ms) {
    if (ms == NULL) {
        msError("Error: msString is NULL.");
        return -1;
    }
    return *((long int *)ms);
}

int msCompare(msString ms1, msString ms2) {
    if (ms1 == NULL || ms2 == NULL) {
        msError("Error: One of the msStrings is NULL.");
        return -1;
    }

    long int len1 = *((long int *)ms1);
    long int len2 = *((long int *)ms2);
    if (len1 != len2) {
        return 1;
    }

    int comparison_result =  memcmp((char *)ms1 + sizeof(long int), (char *)ms2 + sizeof(long int), len1);
    return(comparison_result !=0)?1:0; /*ensures the value returned is either a zero or a one*/
}


int msCompareString(msString ms, char *str) {
    if (ms == NULL || str == NULL) {
        msError("Error: msString or input string is NULL.");
        return -1;
    }

    long int len = *((long int *)ms);

    if (len != strlen(str)) {
        return 1;
    }

    int comparison_result = memcmp((char *)ms + sizeof(long int), str, len);
    return (comparison_result !=0)?1:0; /*ensure that a 0 or 1 value is returned when the comparison is made*/
}


static void msError(char *msg) {
    fprintf(stderr, "%s\n", msg);/*writes the error to stderror*/
    exit(EXIT_FAILURE);
}

