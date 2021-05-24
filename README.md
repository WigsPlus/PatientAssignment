# Hospital README

## Short summery

Chose the *Patient* assigment. Created a *Singleton Design Pattern* for the mockup data instead of a sql database. This is also mentioned in the project. Used mapping and Data transfer object (DTO) and dependency injection.

It is possible to:
* Create new doctor
* Check if doctor X has access to patient Y medical journal
* See list of doctors

## Postman

Getting a doctor which is authorized for a patient on a admission:

http://localhost:5000/api/Admissions/67048766/0  --  Changing the "0" to "1" will give a no permission since that doctor is not authorized to that patient

Getting all doctors:

http://localhost:5000/api/Doctors

Getting a single doctor by ID:

http://localhost:5000/api/doctors/doctorId=0

Creating a doctor with a JSON body:

http://localhost:5000/api/doctors/

{
    "doctorId": 5,
    "name": "Jørgen",
    "department": "Århus"
}



## Docker Setup

In terminal for setup: (Properly not needed)

docker build -t wiggersdocker/hospital .

Running the container from the dockerhub:

docker run -p 8080:5000 wiggersdocker/hospital 
