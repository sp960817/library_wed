/*
MySQL Backup
Source Server Version: 5.5.58
Source Database: sql10225820
Date: 2018/3/11 01:09:56
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
--  Table structure for `admin`
-- ----------------------------
DROP TABLE IF EXISTS `admin`;
CREATE TABLE `admin` (
  `AdminName` varchar(50) NOT NULL,
  `AdminPassword` varchar(50) NOT NULL,
  `AdminRealName` varchar(50) NOT NULL,
  PRIMARY KEY (`AdminName`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
--  Table structure for `book_style`
-- ----------------------------
DROP TABLE IF EXISTS `book_style`;
CREATE TABLE `book_style` (
  `bookstyleno` int(11) NOT NULL AUTO_INCREMENT COMMENT '种类编号',
  `bookstyle` varchar(255) NOT NULL COMMENT '种类名称',
  PRIMARY KEY (`bookstyleno`),
  KEY `bookstyle` (`bookstyle`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8;

-- ----------------------------
--  Table structure for `borrow_record`
-- ----------------------------
DROP TABLE IF EXISTS `borrow_record`;
CREATE TABLE `borrow_record` (
  `id` int(255) NOT NULL AUTO_INCREMENT,
  `bookid` int(255) NOT NULL,
  `bookname` varchar(255) NOT NULL,
  `readerid` varchar(255) NOT NULL,
  `borrowdate` date NOT NULL,
  `isreturn` varchar(11) NOT NULL DEFAULT '否',
  PRIMARY KEY (`id`),
  KEY `bookid` (`bookid`,`bookname`),
  KEY `readerid` (`readerid`),
  CONSTRAINT `borrow_record_ibfk_2` FOREIGN KEY (`readerid`) REFERENCES `system_readers` (`readerid`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `borrow_record_ibfk_1` FOREIGN KEY (`bookid`, `bookname`) REFERENCES `system_book` (`bookid`, `bookname`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
--  Table structure for `re_borrow_record`
-- ----------------------------
DROP TABLE IF EXISTS `re_borrow_record`;
CREATE TABLE `re_borrow_record` (
  `id` int(255) NOT NULL AUTO_INCREMENT,
  `bookid` int(255) NOT NULL,
  `bookname` varchar(255) NOT NULL,
  `readerid` varchar(255) NOT NULL,
  `re_borrowdate` date NOT NULL,
  PRIMARY KEY (`id`),
  KEY `bookid` (`bookid`,`bookname`),
  KEY `readerid` (`readerid`),
  CONSTRAINT `re_borrow_record_ibfk_2` FOREIGN KEY (`readerid`) REFERENCES `system_readers` (`readerid`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `re_borrow_record_ibfk_1` FOREIGN KEY (`bookid`, `bookname`) REFERENCES `system_book` (`bookid`, `bookname`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
--  Table structure for `return_record`
-- ----------------------------
DROP TABLE IF EXISTS `return_record`;
CREATE TABLE `return_record` (
  `id` int(255) NOT NULL AUTO_INCREMENT,
  `bookid` int(11) NOT NULL,
  `bookname` varchar(255) NOT NULL,
  `readerid` varchar(255) NOT NULL,
  `returndate` date DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `bookid` (`bookid`,`bookname`),
  KEY `readerid` (`readerid`),
  CONSTRAINT `return_record_ibfk_2` FOREIGN KEY (`readerid`) REFERENCES `system_readers` (`readerid`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `return_record_ibfk_1` FOREIGN KEY (`bookid`, `bookname`) REFERENCES `system_book` (`bookid`, `bookname`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
--  Table structure for `system_book`
-- ----------------------------
DROP TABLE IF EXISTS `system_book`;
CREATE TABLE `system_book` (
  `bookid` int(11) NOT NULL AUTO_INCREMENT,
  `bookname` varchar(255) CHARACTER SET utf8 NOT NULL,
  `bookstyle` varchar(255) CHARACTER SET utf8 NOT NULL,
  `bookauther` varchar(255) CHARACTER SET utf8 NOT NULL,
  `bookstock` int(11) NOT NULL,
  `bookpub` varchar(255) CHARACTER SET utf8 DEFAULT NULL,
  `bookpubdate` date DEFAULT NULL,
  `isborrowed` varchar(255) CHARACTER SET utf8 DEFAULT NULL COMMENT '是否被预约借阅',
  `bookrecommend` varchar(255) CHARACTER SET utf8 DEFAULT NULL COMMENT '书籍推荐',
  `booklv` int(11) DEFAULT NULL,
  PRIMARY KEY (`bookid`),
  KEY `bookstyle` (`bookstyle`),
  KEY `bookid` (`bookid`,`bookname`),
  CONSTRAINT `system_book_ibfk_1` FOREIGN KEY (`bookstyle`) REFERENCES `book_style` (`bookstyle`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

-- ----------------------------
--  Table structure for `system_readers`
-- ----------------------------
DROP TABLE IF EXISTS `system_readers`;
CREATE TABLE `system_readers` (
  `readerid` varchar(255) CHARACTER SET utf8 NOT NULL COMMENT '读者id',
  `readerpw` varchar(255) CHARACTER SET utf8 NOT NULL COMMENT '读者密码',
  `readername` varchar(255) CHARACTER SET utf8 NOT NULL COMMENT '读者姓名',
  PRIMARY KEY (`readerid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
--  Records 
-- ----------------------------
INSERT INTO `admin` VALUES ('sp','573F5E80E4CD6FBEB12AC2B6DB3E47AF','孙鹏');
INSERT INTO `book_style` VALUES ('6','交通运输'), ('8','医学科学'), ('3','历史地理'), ('1','哲学宗教'), ('7','政治法律'), ('4','数理科学'), ('2','文学艺术'), ('5','生物科学');
INSERT INTO `system_book` VALUES ('1','美国大城市','医学科学','阿萨德','455','阿萨德','2018-01-12','否','阿萨德','3'), ('2','奥术大师多','交通运输','但是我','28','地方','2018-02-27','否','',NULL);
INSERT INTO `system_readers` VALUES ('1','q','h'), ('2014020332038','q9t3e5q2','孙鹏'), ('255','q','孙鹏'), ('55','mengmenga','刘畅');
