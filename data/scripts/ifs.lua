function GetKey(fname, sect, key) -- возвращает значения секции 
  return IFS:GetPrivateString("..\\data\\configs\\"..fname..".ini", sect, key)
end