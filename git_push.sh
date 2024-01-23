## before run this code first run the following lines: not .bashrc  (.bashrc vs .bash_profile vs .profile)
#echo "export PWDGITHUB=ghp_AfjhGtJMGBOsaBJvzsShQqZ6dl7QGoKHH" >> ~/.profile

localsecret=./git_pwd

echo "start to commit, push to remote repo"
 git add . &&\
 git commit -m "devop temporary saving " &&\
 
GIT_ASKPASS=$localsecret git push -f &&\
printf "\033[0;31m git push is done locally \033[0m\n\n"