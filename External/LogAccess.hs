module External.LogAccess (getLogUrl, getTodayLogUrl) where

import Data.Text
import Data.Time.Clock
import Data.Time.Calendar
import Prelude hiding (concat)

logUrlPrefix :: Text
logUrlPrefix = "http://0xd34df00d.me/logs/chat/codingteam@conference.jabber.ru"

pad :: Show a => Int -> a -> Text
pad p = justifyRight p '0' . pack . show

getLogUrl :: (Integer, Int, Int) -> Text
getLogUrl (year, month, day) = concat [logUrlPrefix, "/", pad 4 year, "/", pad 2 month, "/", pad 2 day, ".html"]

getDate :: IO (Integer, Int, Int)
getDate = getCurrentTime >>= return . toGregorian . utctDay

getTodayLogUrl :: IO Text
getTodayLogUrl = do
    date <- getDate
    return $ getLogUrl date
