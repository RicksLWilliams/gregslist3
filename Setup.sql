CREATE TABLE cars(
 id INT NOT NULL AUTO_INCREMENT,
 make VARCHAR(255) NOT NULL,
 model VARCHAR(255) NOT NULL,
 imgUrl VARCHAR(255) NOT NULL,
 body VARCHAR(255) NOT NULL,
 price INT NOT NULL,
 productionYear INT NOT NULL,
 userId VARCHAR(255) NOT NULL,
 PRIMARY KEY (id)
)
-- DROP TABLE cars

-- Alter table cars ADD Column productionYear INT NOT NULL


INSERT INTO cars
(make, model, imgUrl, description, year, price, userId)
VALUES
("Chevy","Tracker", "https://lh3.googleusercontent.com/proxy/7JSA0qnl12LyOlLe_nZxAWZ-0YCLvxSkBPJHcYRCs8b-Kh6sXtBX4p-AcWpqAnK5C6YSKlP6GEVOKlgG6ERcaB9IcnTzXZ2lWnfzP4mcDEtOPe87k-XoSzLI6f4rjVhDD_JWDA", "Itsa tracker", 1989, 2000, "D$")
