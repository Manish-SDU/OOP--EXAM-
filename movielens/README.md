Look at the “Read Csv” Link in the Plan and add two models, one for movies.csv and one for ratings.csv.
Read the CSVs into two collections using the CsvHelper library
Task 2 - Merge the databases
Use the LINQ Join operation to merge both movies and ratings into a single movie_ratings collection.

Task 3 - Find the 100 highest rated movies
Use group by and average to find the average userrating for each movie
Use sort and take to get the 100 highest rated movies
You might notice that the resulting list is not what you would expect. Most movies are not very well known. Try to fix it. Hint: Count 
Turn the Genres string feature into a list of strings and calculate the percentage of the occurence of each genre in the 100 highest rated movies.