CREATE TABLE jobs (
  id INT NOT NULL AUTO_INCREMENT,
  userId VARCHAR(255) NOT NULL,
  company VARCHAR(255),
  jobTitle VARCHAR(255),
  hours int,
  rate int,
  description VARCHAR(255),
  PRIMARY KEY (id)
);

insert into jobs (userId, company, jobTitle, hours, rate, description)
values ('userId', 'company', 'jobTitle', 40, 50, 'description')