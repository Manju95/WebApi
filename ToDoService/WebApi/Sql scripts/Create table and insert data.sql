CREATE TABLE TASK
(
ID INT PRIMARY KEY,
CREATEDDATE DATETIME,
DESCRIPTION VARCHAR(100) 
);

INSERT INTO TASK VALUES(1,'2020-01-21 19:30:06.337','wake up')
INSERT INTO TASK VALUES(2,'2020-01-21 19:30:06.337','Get ready')

select * from TASK

insert into task(CREATEDDATE,DESCRIPTION) values('2020-01-21 19:30:06.337','test')
