module Handler.Index where

import Import
import Yesod.Form.Bootstrap3 (BootstrapFormLayout (..), renderBootstrap3,
                              withSmallInput)

getIndexR :: Handler Html
getIndexR = do
    defaultLayout $ do
        setTitle "codingteam"
        $(widgetFile "index/index")
