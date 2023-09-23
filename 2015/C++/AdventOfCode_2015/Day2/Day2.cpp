#include <iostream>
#include <fstream>
#include <string>
#include <stdexcept>
#include <vector>

#include "Day2.hpp"

int main()
{
    part_one();
    part_two();
}

void part_one() {

    // Running total of wrapping paper sq ft
    int sqft = 0;

    // String containing the puzzle input
    std::vector<std::string> boxSizes;
}

void part_two() {

}

void process_input(std::vector<std::string>& boxSizes) {
    
    // String containing the puzzle input
    std::string curBoxSize;

    // File stream to read puzzle input
    std::ifstream myfile("input.txt");

    // Check if the file is open
    if (myfile.is_open()) {
        
        // Read the file one line at a time
        while (std::getline(myfile, curBoxSize)) {
            
        }
    }
    else {

        // Exit if we can't read the file
        throw std::invalid_argument("Could not open file 'input.txt'");
    }
}
