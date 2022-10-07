CREATE TABLE Agents (
agent_id varchar(255) NOT NULL PRIMARY KEY,
hire_date date NOT NULL,
agent_status_code varchar(255) NOT NULL,
salary int NOT NULL,
comission decimal NULL,
FOREIGN KEY (agent_id) REFERENCES Agents(agent_id) );

CREATE TABLE Performances (
performance_id varchar(255) NOT NULL  PRIMARY KEY,
performance_date date NOT NULL,
venue_id varchar(255) NOT NULL FOREIGN KEY REFERENCES Venues(venue_id),
revenue int NULL,
agent_id varchar(255) NOT NULL FOREIGN KEY REFERENCES Agents(agent_id) );

CREATE TABLE Venues (
venue_id varchar(255) NOT NULL PRIMARY KEY,
venue_name varchar(255) NOT NULL,
street_address varchar(255) NOT NULL,
zip_code char(5) NOT NULL,
zip_code_ext char(4) NOT NULL,
contact_phone char(10) NOT NULL, 
FOREIGN KEY (zip_code) REFERENCES Zips(zip_code) );

CREATE TABLE Zips (
zip_code char(5) NOT NULL PRIMARY KEY,
city varchar(100) NOT NULL,
longitude decimal NOT NULL,
latitude decimal NOT NULL );

INSERT INTO Zips (zip_code, longitude, latitude, city) VALUES (72701, -94.137650, 36.0404670, 'Fayetteville');

INSERT INTO Agents (agent_status_code, hire_date, salary, comission, agent_id) VALUES ('A', '2022-10-04', 50000, .10, 1);

INSERT INTO Venues (venue_id, venue_name, street_address, zip_code, zip_code_ext, contact_phone) 
VALUES 
('jjbg', 'JJs Bar and Grill', '324 W Dickson St', 72701, 0002, 9785156674),
('grgs', 'Georges Lounge', '519 W Dickson St', 72701, 0001, 4795430023);
