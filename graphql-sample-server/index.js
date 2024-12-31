const { ApolloServer } = require('@apollo/server')
const express = require('express')
const cors = require('cors')
const bodyParser = require('body-parser')
const { expressMiddleware } = require('@apollo/server/express4')

const typeDefs = `
    type Query {
      hello: String
      getNumber: Int
    }   
    type Mutation {
        setNumber(value: Int!): Int
    }
`;

let storedNumber = 42;

const resolvers = {
    Query: {
        hello: () => 'Hello, world!',
        getNumber: () => storedNumber,
    },
    Mutation: {
        setNumber: (value) => {
            storedNumber = value
            return storedNumber
        },
    }
};

const server = new ApolloServer({
    typeDefs,
    resolvers,
});

const app = express();
server.start().then( () => {
    app.use(cors(), bodyParser.json(), expressMiddleware(server));
    app.listen(4000, () => {
        console.log(`GraphQL server running at http://localhost:4000/graphql`);
    })
} )