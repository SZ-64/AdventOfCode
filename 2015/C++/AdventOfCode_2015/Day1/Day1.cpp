#include <iostream>
#include <fstream>
#include <string>

#include "Day1.hpp"

int main()
{
    partOne();
    partTwo();
}

void partOne() {
    
    // Int to track the current floor
    int floor = 0;

    // String containing the puzzle input
    std::string parens;

    // File stream to read puzzle input
    std::ifstream myfile("input.txt");

    // Check if the file is open
    if (myfile.is_open()) {

        // Read the file into the string
        myfile >> parens;

        // Iterate over the string
        for (int i = 0; i < parens.size(); i++) {

            // Add a floor on ( and subtract a floor on )
            if (parens[i] == '(')
                floor++;
            else if (parens[i] == ')')
                floor--;
        }

        // Output the result to the console
        std::cout << floor << std::endl;
    }
}

void partTwo() {
    
    // Int to track the current floor
    int floor = 0;
    int basementPos = 0;

    // String containing the puzzle input
    std::string parens;

    // File stream to read puzzle input
    std::ifstream myfile("input.txt");

    // Check if the file is open
    if (myfile.is_open()) {

        // Read the file into the string
        myfile >> parens;

        // Iterate over the string
        for (int i = 0; i < parens.size(); i++) {

            // Check if underground and this is the first time
            if (floor < 0 && basementPos == 0)
                basementPos = i;

            // Add a floor on ( and subtract a floor on )
            if (parens[i] == '(')
                floor++;
            else if (parens[i] == ')')
                floor--;
        }

        // Output the results to the console
        std::cout << floor << std::endl;
        std::cout << basementPos << std::endl;
    }
}
