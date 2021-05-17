--create table RegisteredUsers (
--SocSecNb nvarchar(11),
--PW int,
--Height int)

--insert into RegisteredUsers (SocSecNb, PW, Height) values ('123456-7890',1234,185)
--insert into RegisteredUsers (SocSecNb, PW, Height) values ('234567-8901',2345,174)
--insert into RegisteredUsers (SocSecNb, PW, Height) values ('345678-9012',3456,193)

--create table WeightData (
--SocSecNb nvarchar(11),
--Weight decimal(3,1),
--Date date)

--insert into WeightData (SocSecNb, Weight, Date) values ('123456-7890',86.4,'2015-01-03')
--insert into WeightData (SocSecNb, Weight, Date) values ('234567-8901',75.8,'2015-01-03')
--insert into WeightData (SocSecNb, Weight, Date) values ('345678-9012',75.8,'2015-01-03')
--insert into WeightData (SocSecNb, Weight, Date) values ('123456-7890',95.1,'2015-01-03')
--insert into WeightData (SocSecNb, Weight, Date) values ('123456-7890',85.3,'2015-01-07')
--insert into WeightData (SocSecNb, Weight, Date) values ('234567-8901',81.1,'2015-01-10')
--insert into WeightData (SocSecNb, Weight, Date) values ('345678-9012',72.0,'2015-01-06')
--insert into WeightData (SocSecNb, Weight, Date) values ('234567-8901',95.3,'2015-01-07')
--insert into WeightData (SocSecNb, Weight, Date) values ('345678-9012',86.4,'2015-01-12')
--insert into WeightData (SocSecNb, Weight, Date) values ('123456-7890',82.3,'2015-01-11')

--create table BloodSugarData (
--SocSecNb nvarchar(11),
--BloodSugar decimal(3,2),
--Date date)

--insert into BloodSugarData (SocSecNb, BloodSugar, Date) values ('123456-7890',8.0,'2015-01-05')
--insert into BloodSugarData (SocSecNb, BloodSugar, Date) values ('234567-8901',5.3,'2015-01-05')
--insert into BloodSugarData (SocSecNb, BloodSugar, Date) values ('345678-9012',8.7,'2015-01-05')
--insert into BloodSugarData (SocSecNb, BloodSugar, Date) values ('123456-7890',8.6,'2015-01-06')
--insert into BloodSugarData (SocSecNb, BloodSugar, Date) values ('123456-7890',4.1,'2015-01-09')
--insert into BloodSugarData (SocSecNb, BloodSugar, Date) values ('234567-8901',6.5,'2015-01-06')
--insert into BloodSugarData (SocSecNb, BloodSugar, Date) values ('345678-9012',7.7,'2015-01-07')
--insert into BloodSugarData (SocSecNb, BloodSugar, Date) values ('234567-8901',9.8,'2015-01-08')
--insert into BloodSugarData (SocSecNb, BloodSugar, Date) values ('345678-9012',9.2,'2015-01-11')
--insert into BloodSugarData (SocSecNb, BloodSugar, Date) values ('123456-7890',5.4,'2015-01-12')

--create table BloodPressure (
--SocSecNb nvarchar(11),
--Systolic int,
--Diastolic int,
--Date date)

--insert into BloodPressure (SocSecNb, Systolic, Diastolic, Date) values ('123456-7890',110,80,'2015-01-5')
--insert into BloodPressure (SocSecNb, Systolic, Diastolic, Date) values ('234567-8901',115,85,'2015-01-05')
--insert into BloodPressure (SocSecNb, Systolic, Diastolic, Date) values ('345678-9012',120,75,'2015-01-05')
--insert into BloodPressure (SocSecNb, Systolic, Diastolic, Date) values ('123456-7890',125,100,'2015-01-05')
--insert into BloodPressure (SocSecNb, Systolic, Diastolic, Date) values ('123456-7890',130,95,'2015-01-05')
--insert into BloodPressure (SocSecNb, Systolic, Diastolic, Date) values ('234567-8901',135,90,'2015-01-05')
--insert into BloodPressure (SocSecNb, Systolic, Diastolic, Date) values ('345678-9012',140,85,'2015-01-05')
--insert into BloodPressure (SocSecNb, Systolic, Diastolic, Date) values ('234567-8901',110,80,'2015-01-05')
--insert into BloodPressure (SocSecNb, Systolic, Diastolic, Date) values ('345678-9012',115,100,'2015-01-05')
--insert into BloodPressure (SocSecNb, Systolic, Diastolic, Date) values ('123456-7890',120,95,'2015-01-05')

--select * from RegisteredUsers where SocSecNb ='123456-7890' AND PW = 1234  

select * from RegisteredUsers where SocSecNb = '123456-7890'