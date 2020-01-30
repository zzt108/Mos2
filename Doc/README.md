Dear Zsolt,

The Israeli Mossad, due to it's special recruitment methods, has access to all developers in the world.  
Their cyber units are rapidly growing, and the recruitment process must be improved to stand their needs.  
The challenge is to filter out and find the best matching candidates for the right position.  
Your task will be to craft a BE application, that will handle a vast amount of data and provide a REST API for the FE team.  

### The Mossad recruiter is expecting to be able to:
1. Insert a match criteria - a combination of a technology (from a list) and years of experience (a number)
2. Swipe left or right on a candidate, which will mark him/her as accepted or rejected
3. View a list of all accepted candidates
4. Appoint any accepted candidate to be a recruiter
5. Log into the system by inserting his email (only for recruiters)

### Data from the scouting department
Get technologies:  
https://v1.ifs.aero/technologies/  
Get candidates:  
https://v1.ifs.aero/candidates/  

### A few things to notice
1. The Mossad doesn't give second chances. Regardless of accepting or rejecting a candidate, he/she should never be shown again
2. The data set of candidates is vast and quickly growing, the client app should not slow down with growth of the list to 100k records
3. Against all best practices, please ignore security (auth) in this task. The login endpoint shall return the current user info, but no token is necessary and no need to add auth to other endpoints
4. No need to store/return all data from jsons, please choose only what you like - keep it simple
5. If you use a DB, it must be stored within the solution and submitted in the repo
6. Tests coverage is a large plus
7. Please don't spend more than 4 hours on this task, it's alright if you don't complete it

Please submit your solution into this repository.  
Don't hesitate to contact us on any question you might have :)  

Good luck!
