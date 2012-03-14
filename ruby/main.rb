require 'sinatra'
require 'json'

post '/' do
  payload = JSON.parse(params[:payload])
  pp payload
end
