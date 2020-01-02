查看端口被哪个应用占用

netstat -ano 
netstat -aon|findstr "49157" 
tasklist|findstr "2720"