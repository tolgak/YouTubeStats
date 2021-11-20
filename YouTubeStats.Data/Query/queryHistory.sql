select v.Id VideoId
--     , v.Title
     , v.PublishedAt
     , cast( julianday(h.RequestBegin) - julianday(v.PublishedAt) as integer) DaysOnAir 
     , h.viewCount / cast( julianday(h.RequestBegin) - julianday(v.PublishedAt) as integer) AverageDailyView
     , h.viewCount
     , h.likeCount
     , h.dislikeCount
     , h.commentCount
     , h.SubscriberCount
     , h.RequestBegin
  from Video v
  join History h on h.VideoId = v.Id
  where v.Id = @Id
  order by datetime(h.RequestBegin) desc