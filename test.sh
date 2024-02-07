# curl -X 'POST' -k 'https://localhost:7070/api/Auth/Register' -H 'accept: */*'  -H 'Content-Type: application/json' \
#   -d '{
#   "phNo": "8326667777",
#   "password": "Sd123$"
# }'

#curl -k -X 'POST' 'https://localhost:7070/api/Auth/Register' -H 'accept: */*'  -H 'Content-Type: application/json' -d '{"phNo": "8325557777","password": "Sd1234$"}'
curl -k -X 'POST' 'https://localhost:7070/api/Auth/Login' -H 'accept: */*'  -H 'Content-Type: application/json'  -d '{ "phNo": "8325557777", "password": "Sd1234$"}'