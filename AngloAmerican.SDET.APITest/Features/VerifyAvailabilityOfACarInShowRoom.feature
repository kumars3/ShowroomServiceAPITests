Feature: VerifyAvailabilityOfACarInShowRoom
	In order to find availability of  a car in the show room
	As an automation tester
	I want to make a call to showroom service end point URL
	So that I can verify wheter a car of a specfied type is available or not

@Positive
Scenario Outline: Verify that the ShowroomService GET API returns a valid car type
Given I have an EndPoint GET Url of ShowRoomService
When I send a request for a specific cartype <type> to the ShowroomService endpoint
Then A valid car details are returned
Examples: 
| type          |
| Saloon        |
| Suv           |
| Hatchback     |

@Negative
Scenario Outline: Verify that the ShowroomService GET API returns an invalid car type
Given I have an EndPoint GET Url of ShowRoomService
When I send a request for a specific cartype <type> to the ShowroomService endpoint
Then A valid car details are returned
Examples: 
| type          |
| MPvs          |
| Coupes        |
| Estates       |