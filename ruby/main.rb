require 'sinatra'
require 'json'

post '/lists/create' do
  payload = JSON.parse(params[:payload])
  pp payload
  pp payload["user_id"]
end
