Linux常用命令
============

### 文件操作
ls -adl ~
cd ../
pwd -P
mkdir -mp 777 /test/test/test
rmdir -p /test/test
cp -a file /file1
rm -fir /test
mv -fiu dir1 dir
chgrp
chown
chmod

### 用户管理
vim /etc/passwd
useradd -c comment - d /usr/jery -m -g mygroup - G othergruop -s /bin/bash 
userdel -r jery
usermod -c modifycomment -d /usr/jery_dir -g modifygroup -s /bin/sh
passwd [-l | -u | -d | -f] [jery]

### 用户组管理
vim /etc/group
groupadd -g 101 -o testgroup
groupmod -g 102 -n newgroupname testgroup
groupdel testgroup
newgrp root

### shell管理
cat /etc/shells
chsh -s /bin/sh
echo $SHELL

### Unknown
- mail spool
