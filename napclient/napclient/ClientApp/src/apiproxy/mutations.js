import gql from "graphql-tag";

const CREATE_TEST = gql`mutation($userTest: UserTestInput!){
    addUserTest(userTest: $userTest){
      id
      testId
      userId
      mode
    }
}`

const ADD_TEST = gql`
  mutation($test: TestInput!) {
    createTest(test: $test) {
      text
      description
      year
      subject
    }
  }
`

const ADD_QUESTION = gql`mutation($question:QuestionInput!){
    addQuestion(question: $question){
      testId
      text
      sequence
      questionType
      description    
    }
  }
`

const DELETE_ANSWER = gql`mutation($id:ID!){
    deleteAnswerById(id:$id)
  }
`

const ADD_ANSWER = gql`mutation($answer:AnswerInput!){
    addAnswer(answer: $answer){
      questionId
      text
      description
      isCorrect
    }
  }
`

export 
{ 
      CREATE_TEST, 
      ADD_TEST, 
      ADD_QUESTION,
      DELETE_ANSWER,
      ADD_ANSWER,
}