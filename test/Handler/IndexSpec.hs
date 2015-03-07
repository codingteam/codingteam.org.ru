module Handler.IndexSpec (spec) where

import TestImport

spec :: Spec
spec = withApp $ do
    it "loads the index and checks it looks right" $ do
        get IndexR
        statusIs 200
        htmlAllContain "h1" "codingteam"

    -- This is a simple example of using a database access in a test.  The
    -- test will succeed for a fresh scaffolded site with an empty database,
    -- but will fail on an existing database with a non-empty user table.
    it "leaves the user table empty" $ do
        get IndexR
        statusIs 200
        users <- runDB $ selectList ([] :: [Filter User]) []
        assertEqual "user table empty" 0 $ length users