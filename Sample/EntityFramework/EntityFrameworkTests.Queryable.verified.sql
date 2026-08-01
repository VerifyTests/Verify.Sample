select c.Id,
       c.Content
from   Companies as c
where  c.Content = N'value'
       and c.Id <> '00000000-0000-0000-0000-000000000000'