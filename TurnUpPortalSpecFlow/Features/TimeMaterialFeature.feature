Feature: TimeMaterialFeature

As a TurnUp portal admin user
I would like to create,edit,delete Time and Material records
So that I can manage employees time and materials successfully

@createtimerecord
Scenario:1 Create a Time record with valid data
	Given I logged into TurnUp portal successfully
	When I navigate to the Time and Material page
	And I created a new Time record with '<Code>','<Price>','<Description>'
	Then the Time record should be created successfully with new '<Code>','<Price>','<Description>'
	Examples: 
	| Code       | Price	 | Description           |
	| TimeModule | $40.00    | This is a Time Module |
	

#This will execute 3 times
Scenario Outline:2 Edit the newly created Time record 
	Given I logged into TurnUp portal successfully
	When I navigate to the Time and Material page
	And I updated the '<EditedCode>','<EditedPrice>','<EditedDescription>' of Time record
	Then the time record should be updated with new '<EditedCode>','<EditedPrice>','<EditedDescription>'
	Examples: 
	| EditedCode  | EditedPrice	| EditedDescription    |
	| EditedCode1 | $60.00		| This is edited record |
	| EditedCode2 | $56.00		| This is edited record |
	| EditedCode3 | $78.00		| This is edited record |

Scenario Outline:3 Delete newly created Time record 
	Given I logged into TurnUp portal successfully
	When I navigate to the Time and Material page
	And I deleted a Time record with '<Code>'
	Then the Time record with '<Code>' should be deleted successfully
	Examples: 
	| Code        |
	| EditedCode3 |