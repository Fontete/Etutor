use eTutor
go
--------------------------------------------
select * from Tutors
select * from Staffs
select * from Students
--------------Add data to Accounts table--------------------
--------------Add staff account--------------------
insert into Accounts(Username,[Password],[Role])
values ('staff','12345',1)
insert into Accounts(Username,[Password],[Role])
values ('staff1','12345',1)
insert into Accounts(Username,[Password],[Role])
values ('staff2','12345',1)
insert into Accounts(Username,[Password],[Role])
values ('staff3','12345',1)
--------------Add student account--------------------
insert into Accounts(Username,[Password],[Role])
values ('student','12345',3)
insert into Accounts(Username,[Password],[Role])
values ('student1','12345',3)
insert into Accounts(Username,[Password],[Role])
values ('student2','12345',3)
insert into Accounts(Username,[Password],[Role])
values ('student3','12345',3)
insert into Accounts(Username,[Password],[Role])
--------------Add tutor account--------------------
values ('tutor','12345',2)
insert into Accounts(Username,[Password],[Role])
values ('tutor1','12345',2)
insert into Accounts(Username,[Password],[Role])
values ('tutor2','12345',2)
insert into Accounts(Username,[Password],[Role])
values ('tutor3','12345',2)
--------------Add data to Staffs table--------------------
insert into Staffs(Id,Name,Phone,Email)
values ('1','Maxi','0900990099','staff@uog.com')
insert into Staffs(Id,Name,Phone,Email)
values ('2','Joe','08008800888','staff1@uog.com')
insert into Staffs(Id,Name,Phone,Email)
values ('3','Kate','0787890000','staff2@uog.com')
insert into Staffs(Id,Name,Phone,Email)
values ('4','Bee','09877789900','staff3@uog.com')
--------------Add data to Students table--------------------
insert into Students(Id,Name,Phone,Email)
values ('5','Chaly','0709809000','student@uog.com')
insert into Students(Id,Name,Phone,Email)
values ('6','Wilson','020099889','student1@uog.com')
insert into Students(Id,Name,Phone,Email)
values ('7','Fred','0787890000','student2@uog.com')
insert into Students(Id,Name,Phone,Email)
values ('8','Paul','0989071811','student3@uog.com')
--------------Add data to Tutors table--------------------
insert into Tutors(Id,Name,Phone,Email)
values ('9','Alonso','3478010088','tutor@uog.com')
insert into Tutors(Id,Name,Phone,Email)
values ('10','Fernando','568190000','tutor1@uog.com')
insert into Tutors(Id,Name,Phone,Email)
values ('11','David','234671000','tutor2@uog.com')
insert into Tutors(Id,Name,Phone,Email)
values ('12','John','9018771771','tutor3@uog.com')