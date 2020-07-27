import gql from "graphql-tag";

const GET_TEST = gql`query($userTestId: ID!) {
    testByUserTestId(userTestId: $userTestId) {
      id
      text
      description
      durationMinutes
      questions {
        id
        text
        description
        questionType
        answers {
          id
          text
          isCorrect
          description
        }
        images {
            id
        }
      }
    }
  }
`

const GET_USERTEST_RECORD = gql`
  query($userTestId: ID!, $questionId: ID!) {
    userTestRecord(userTestId: $userTestId, questionId: $questionId) {
      questionId
      userTestId
      answerId
      isCorrect
      answerText
    }
  }
`

const GET_TESTS = gql`
  query {
    tests {
      id
      text
      description
      subject
      year
    }
  }
`

const GET_QUESTIONS = gql`
  query questions($testId: ID!) {
    questions(testId: $testId) {
      id
      text
      description
      sequence
      plainText
    }
  }
`

const GET_ANSWERS = gql`query($questionId:ID!){
    question(questionId:$questionId){
      id
      text
      plainText
      description
      answers{
        id
        text
        description
        sequence
        isCorrect
      }
    }
  }
  `

export 
{   GET_TEST, 
    GET_USERTEST_RECORD, 
    GET_TESTS,GET_QUESTIONS,
    GET_ANSWERS
};