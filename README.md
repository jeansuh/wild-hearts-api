# Wild Hearts API

## INTRODUCTION
Welcome to Wild Hearts API!

This is an API to look up monsters(Kemonos) and the materials you can get from each monsters.

This API includes the basic monster (kemono) data, and different variations of the basic monsters were not included.

**Changes**

Weapons and armors are not included.
Kemono weaknesses are not included.
Kemono parts details were replaced with information regarding breakable parts and the materials they drop when broken.


## INSTRUCTION

### API Endpoints

List all Kemonos:
```https://localhost:7066/api/kemono/```

List Kemono by id:
```https://localhost:7066/api/kemono/1```

List all Materials:
```https://localhost:7066/api/material```

List Material by id:
```https://localhost:7066/api/material/1```

Filter Kemono by Habitat:
```https://localhost:7066/api/kemono/habitat/natsukodachi%20isle``` 

Filter Kemono by Chapter:
```https://localhost:7066/api/kemono/chapter/1``` 

Filter Material by KemonoId:
```https://localhost:7066/api/material/kemonoid/1``` 

Look up Material by MaterialName:
```https://localhost:7066/api/material/materialname/ragetail%20pelt``` 

----------

### HTTP Methods

**Kemono**

GET: api/Kemono

GET: api/Kemono/5

PUT: api/Kemono/5

POST: api/Kemono

DELETE: api/Kemono/5


**Material**

GET: api/Material

GET: api/Material/5

PUT: api/Material/5

POST: api/Material

DELETE: api/Material/5


----------

### Controllers
Kemono controller

Material controller

----------

### SQL

**Tables**
1. Kemonos
2. Materials

**Primary Keys**
1. KemonoId
2. MaterialId

**Foreign Keys**
1. KemonoMaterial
2. KemonoId

**Constraints**
1. KemonoName is uique
2. MaterialName is not null
3. KemonoName is not null
4. Foreign & primary keys

