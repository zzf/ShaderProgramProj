global_num = 3
mytable = mytable or {1, 2, 3, 4}
local this = mytable
local local_num = 0
this.table_num = 3

mytable.tableFunc = function()
	print('Call Lua Function : tableFunc')
end

function Count()
	global_num = global_num + 1
	print('Count + 1, cur Count = ' .. tostring(global_num))
	return global_num
end

function InputValue(param)
	print('Lua Call function InputValue params: ' .. tostring(param))
end