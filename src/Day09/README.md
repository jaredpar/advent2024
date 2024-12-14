# Advent Of Code 2024 Day 9

Solution for [Day 9](https://adventofcode.com/2024/day/9)

For part 1 I used an array but really should have seen the fact a linked list would eventually be required later.

This took embarassingly long to solve. I made the bad assumption that the bubble sort approach would be too slow and started with an optimized implementation. That implementation was very hard to debug and track. Eventually I wrote the slow one impl so I could debug the optimized one but turns out bubble sort was more than fast enough here.
