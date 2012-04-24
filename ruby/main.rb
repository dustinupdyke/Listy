require 'sinatra'
require 'json'
require 'mongo'

get '/' do
  erb :index, :layout => :application
end

get '/lists' do
  erb :index, :layout => :application
end

get '/lists/:list_id' do |list_id|
  erb :index, :layout => :application
end

get '/lists/read/:list_id' do |list_id|
  list_id
end

post '/lists/create' do
  payload = JSON.parse(request.body.read)
  con= Mongo::Connection.new
  db= con['listy'] 
  lists = db['lists']
  lists.save(payload)
end


class ListyList
	attr_accessor :Id, :UserId, :Items
  def initialize
    self.Items = []
  end
end

class ListyItem
  attr_accessor :Id, :Artist, :Song, :VideoUrl, :ThumbUrl, :Comments
end
