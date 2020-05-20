CREATE TABLE houses (
  id INT NOT NULL AUTO_INCREMENT,
  bedrooms int,
  bathrooms int,
  levels int,
  year int,
  price int,
  imgUrl VARCHAR(255),
  description VARCHAR(255),
  userId VARCHAR(255) NOT NULL,
  PRIMARY KEY (id)
)

insert into houses (bedrooms,bathrooms,year, price, levels,imgUrl, description, userId )
values (1,1, 2000, 200000, 1 , 'https://i.pinimg.com/originals/ba/f7/0c/baf70c5b98139b74bff7235a25183a4c.jpg', 'nice house', 'test')