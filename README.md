```
Run the app from VS or via command line (dotnet run -p TopRecords/TopRecords.csproj)

Console Input/Output:
Please insert full file path:
/Users/julka/Desktop/highest_score_recs.data
Please insert max n of results (int):
3
[
  {
    "score": 13214012,
    "id": "085a11e1b82b441184f4a193a3c9a13c"
  },
  {
    "score": 11446512,
    "id": "84a0ccfec7d1475b8bfcae1945aea8f0"
  },
  {
    "score": 11269569,
    "id": "7ec85fe3aa3c4dd599e23111e7abf5c1"
  }
]
```

# Highest Scores
​
### Problem Text:
​
Given a data file containing scored records, in your favorite
programming language, write a program to output the N highest record IDs & scores by score in descending order, highest score first. The output should be correctly formatted JSON. The program should take the file path of the data file as it's first parameter, and
number of scores to return as it's second parameter, like so:
```
./highest score_recs.data 25
```
​
The input data file has a record per line. Each line has the following structure:
```
<score>: <json string>
```
If the line has a score that would make it part of the highest scores, then the remainder of the line _must_ be parsable as JSON, and there must be an "id" key at the top level of this JSON doc. 
​
An example data file could look like this:
​
```
10622876: {"umbrella": 99180, "name": "24490249af01e145437f2f64d5ddb9c04463c033", "value": 12354, "payload": "........", "date_stamp": 58874, "time": 615416, "id": "3c867674494e4a7aac9247a9d9a2179c"}
13214012: {"umbrella": 924902, "name": "70dd4d9494d1cd0362e123ce90f4053726b29e97", "value": 976852, "payload": "........", "date_stamp": 3255, "time": 156309, "id": "085a11e1b82b441184f4a193a3c9a13c"}
11446512: {"umbrella": 727371, "name": "8e21427b2350023079835361dce03cdea95a2983", "value": 70801, "payload": "........", "date_stamp": 1730, "time": 496866, "id": "84a0ccfec7d1475b8bfcae1945aea8f0"}
11025835: === THIS IS NOT JSON and should error if this line is part of the result set, but is ok if it not ==
11269569: {"umbrella": 902167, "name": "e4898b9bf79831cf36811917a797ef0fcf3af636", "value": 593180, "payload": "........", "date_stamp": 58736, "time": 1014495, "id": "7ec85fe3aa3c4dd599e23111e7abf5c1"}
11027069: {"umbrella": 990975, "name": "8aa306fb59e275a7e39debb1d5113ff411df22ad", "value": 67842, "payload": "........", "date_stamp": 60161, "time": 225413, "id": "f812d487de244023a6a713e496a8427d"}
​
```
​
Note that one of the entries, for score `11025835`, has a document portion that is _not_ JSON. If this line was included in the result set, 
then the program should error, but if not then it should continue.
​
For example, if run with an N of 3 it would produce: 
​
```
$ ./highest score_recs.data 3
[
    {
        "score": 13214012,
        "id": "085a11e1b82b441184f4a193a3c9a13c"
    },
    {
        "score": 11446512,
        "id": "84a0ccfec7d1475b8bfcae1945aea8f0"
    },
    {
        "score": 11269569,
        "id": "7ec85fe3aa3c4dd599e23111e7abf5c1"
    }
]
```
​
But when run with an N that includes that line, it would error:
```
$ ./highest score_recs.data 10
invalid json format No JSON object could be decoded
 THIS IS NOT JSON
```
​
Other requirements / things to note about the data files:
* The `id`s are unique across the data set
* Scores can repeat, but you should only count the `id` of the _last_ line processed as the "winning" `id`.
* Scores are non-negative 32-bit integers.
* The `id` must be at the root level of the JSON object, if it is not present it is a format error..
​
​
Upon successful running, the program should exit with exit code 0, any other errors as described above should exit with a non 0 code.
