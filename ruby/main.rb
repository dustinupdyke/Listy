require 'sinatra'
require 'json'
require 'mongo'

get '/lists' do
  erb :index, :layout => :application
end

post '/lists/create' do
  payload = JSON.parse(request.body.read)
  con= Mongo::Connection.new
  db= con['listy'] 
  lists = db['lists']
  lists.save(payload)
end
