function GetKey(fname, sect, key) -- ���������� �������� ������ 
  return IFS:GetPrivateString("..\\data\\configs\\"..fname..".ini", sect, key)
end